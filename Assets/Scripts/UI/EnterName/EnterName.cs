using System;
using TMPro;
using UnityEngine;

public class EnterName : MonoBehaviour
{
    public delegate void OnNameEntered();
    public event OnNameEntered onNameEntered;
    
    [SerializeField] TMP_InputField inputField;
    
    public void SetName()
    {
        Player.Instance.name = inputField.text;
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
