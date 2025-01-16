using System;
using TMPro;
using UnityEngine;

public class EnterName : MonoBehaviour
{
    public delegate void OnNameEntered();
    public event OnNameEntered onNameEntered;
    
    [SerializeField] private TMP_InputField inputField;
    
    public void SetName()
    {
        Player.Instance.playerName.Value = inputField.text;
        onNameEntered?.Invoke();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
    
    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
