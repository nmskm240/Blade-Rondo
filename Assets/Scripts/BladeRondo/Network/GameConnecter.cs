using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BladeRondo.Network
{    
    public class GameConnecter : MonoBehaviour, IConnecter
    {
        public void Connect()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}