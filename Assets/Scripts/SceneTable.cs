using UnityEngine;
using System.Linq;

[CreateAssetMenu( menuName = "SceneTable", fileName = "SceneTable" )]
public class SceneTable : ScriptableObject
{
    private static readonly string RESOURCE_PATH = "SceneTable";

    [SerializeField]
    private SceneData[] m_sceneList = null;
    
    /// <summary>
    /// シーンテーブルのアセットを読み込む
    /// </summary>
    /// <returns>SceneTableのアセット</returns>
    public static SceneTable LoadAsset()
    {
        var asset = Resources.Load(RESOURCE_PATH) as SceneTable;
        if(asset == null)
        {
            throw new System.IO.FileNotFoundException(RESOURCE_PATH);
        }
        return asset;
    }

    /// <summary>
    /// シーン情報を取得するよ！
    /// </summary>
    /// <param name="i_id">取得したいシーンのID(名前)</param>
    /// <returns>シーン情報</returns>
    public SceneData GetSceneData( string i_id )
    {
        if( string.IsNullOrEmpty( i_id ) )
        {
            // 引数に変な文字列渡してんじゃないのさ！
            throw new System.ArgumentNullException( "i_id" );
        }

        if( m_sceneList == null || m_sceneList.Length == 0 )
        {
            // シーン情報が一つも登録されておらんのだが……。
            Debug.AssertFormat( false, "m_sceneList is empty!" );
            return null;
        }

        return m_sceneList.FirstOrDefault( value => value.ID == i_id );
    }

    /// <summary>
    /// 指定したシーンを親に持つシーンを取得するよ。
    /// </summary>
    public SceneData[] GetChildScenes(string i_sceneId)
    {
        if (string.IsNullOrEmpty(i_sceneId))
        {
            // 引数に変な文字列渡してんじゃないのさ！
            throw new System.ArgumentNullException("i_id");
        }

        if (m_sceneList == null || m_sceneList.Length == 0)
        {
            // シーン情報が一つも登録されておらんのだが……。
            Debug.AssertFormat(false, "m_sceneList is empty!");
            return null;
        }

        return m_sceneList.Where(value => value.ParentId == i_sceneId).ToArray();
    }

} // class SceneTable