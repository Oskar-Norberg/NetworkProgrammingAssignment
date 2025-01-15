using UnityEngine;

public class PauseMenu : MonoBehaviour
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
}
