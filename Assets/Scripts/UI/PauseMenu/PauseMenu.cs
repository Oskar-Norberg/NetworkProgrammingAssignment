using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : NetworkBehaviour
{
    public void EnablePauseMenu()
    {
        TogglePauseMenu(true);
    }

    public void DisablePauseMenu()
    {
        TogglePauseMenu(false);
    }

    private void TogglePauseMenu(bool status)
    {
        gameObject.SetActive(status);
    }

    public void Disconnect()
    {
        NetworkManager.Singleton.Shutdown();
        
        SceneManager.LoadScene("MainMenu");
    }
}
