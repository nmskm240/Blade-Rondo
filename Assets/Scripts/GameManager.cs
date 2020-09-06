using System.Collections;
using UnityEngine;
using BladeRondo.System;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SceneController.Instance.LoadScene("TitleScene");
    }
}