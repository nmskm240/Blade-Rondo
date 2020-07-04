using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonMonoBehaviour<SceneController>
{
    private SceneTable sceneTable = null;

    private IEnumerator LoadSceneProcess(string i_sceneId)
    {
        var sceneData = sceneTable.GetSceneData(i_sceneId);
        if (sceneData == null)
        {
            // そんなシーン、俺は知らん！
            Debug.AssertFormat(false, "The scene is missing! id={0}", i_sceneId, gameObject);
            yield break;
        }


        {
            Scene currentScene = SceneManager.GetSceneByName(sceneData.ID);
            if (currentScene.IsValid())
            {
                // そのシーンは既に読み込まれているようだ。
                // かぶるから読み込みは差し控えさせていただきます。
                Debug.LogWarningFormat("The scene has already been loaded.! id={0}", i_sceneId, gameObject);
                yield break;
            }
        }

        // 同一のカテゴリのシーンを複数存在させない。
        Scene sceneOfSameCategory = GetSceneOfSameCategoryInHerarchy(sceneData);
        if (sceneOfSameCategory.IsValid())
        {
            yield return UnloadSceneProcess(sceneOfSameCategory);
        }

        yield return SceneManager.LoadSceneAsync(sceneData.ID, LoadSceneMode.Additive);
    }

    /// <summary>
    /// シーンを破棄するよ。
    /// 子シーンも破棄するよ。
    /// </summary>
    private IEnumerator UnloadSceneProcess(Scene i_scene)
    {
        if (!i_scene.IsValid())
        {
            throw new System.ArgumentException("i_scene");
        }

        SceneData[] childList = sceneTable.GetChildScenes(i_scene.name);
        if (childList != null)
        {
            foreach (var child in childList)
            {
                Scene childScene = SceneManager.GetSceneByName(child.ID);
                if (childScene.IsValid())
                {
                    // 子シーンの子シーンがいる可能性があるため、再帰する。
                    yield return UnloadSceneProcess(childScene);
                }
            }
        }

        yield return SceneManager.UnloadSceneAsync(i_scene);
    }

    private void Awake()
    {
        sceneTable = SceneTable.LoadAsset();
    }

    public void LoadScene(string sceneId)
    {
        StartCoroutine(LoadSceneProcess(sceneId));
    }

    public void UnloadScene(string sceneId)
    {
        StartCoroutine(UnloadSceneProcess(SceneManager.GetSceneByName(sceneId)));
    }

    /// <summary>
    /// 指定したシーンと同じカテゴリのHerarchy上のシーンを取得するぞ。
    /// </summary>
    private Scene GetSceneOfSameCategoryInHerarchy(SceneData i_sceneData)
    {
        if (i_sceneData == null)
        {
            throw new System.ArgumentNullException("i_sceneData");
        }

        // カテゴリが無いシーンはルートシーン扱い。
        if (string.IsNullOrEmpty(i_sceneData.Category))
        {
            return new Scene();
        }

        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name == i_sceneData.ID)
            {
                continue;
            }

            SceneData sceneData = sceneTable.GetSceneData(scene.name);
            if (sceneData == null)
            {
                continue;
            }

            if (string.IsNullOrEmpty(sceneData.Category))
            {
                continue;
            }

            if (sceneData.Category == i_sceneData.Category)
            {
                return scene;
            }
        }

        return new Scene();
    }
}