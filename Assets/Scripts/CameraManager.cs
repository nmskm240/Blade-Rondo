using UnityEngine;

public class CameraManager : SingletonMonoBehaviour<CameraManager>
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
