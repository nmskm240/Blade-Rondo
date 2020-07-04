using System;
using UnityEngine;
using BladeRondo.System;

public class DebugManager : SingletonMonoBehaviour<DebugManager>
{
    int Id = 1;

    [SerializeField]
    bool IsDebugMode = false;

    int cmdSeq = 0;
    int[] keyCodes;
    int[] konamiCommand = new[] 
    {
        (int)KeyCode.UpArrow,
        (int)KeyCode.UpArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.B,
        (int)KeyCode.A
    };
    int kcnt = 0;

    private void Start()
    {
        keyCodes = (int[])Enum.GetValues(typeof(KeyCode));
    }

    void Update()
    {
        var len = keyCodes.Length;
        for (var i = 0; i < len; i++)
        {
            if (Input.GetKeyUp((KeyCode)keyCodes[i]))
            {
                if (konamiCommand[cmdSeq] == keyCodes[i])
                {
                    cmdSeq++;
                    if (cmdSeq == konamiCommand.Length)
                    {
                        IsDebugMode = !IsDebugMode;
                        Debug.Log("Debug mode " + ((IsDebugMode)? "on" : "off"));
                        cmdSeq = 0;
                    }
                }
                else
                {
                    cmdSeq = 0;
                }
            }
        }
    }

    void OnGUI()
    {
        if(IsDebugMode)
        {
            GUI.Label(new Rect(0, 75, 50, 25), "Sword" + Id);

            if (GUI.Button(new Rect(0, 100, 25, 25), "◀"))
            {
                Id = (Id <= 1) ? 20 : Id - 1;
            }

            if (GUI.Button(new Rect(25, 100, 50, 25), "Create"))
            {
                CardFactory.Instance.Create("Sword" + Id);
            }

            if (GUI.Button(new Rect(75, 100, 25, 25), "▶"))
            {
                Id = (Id >= 20) ? 1 : Id + 1;
            }
        }
    }
}