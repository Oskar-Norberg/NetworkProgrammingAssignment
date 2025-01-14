using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        SceneManager.LoadScene(sceneName);
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }
}
