using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI messageText;

    public void SetMessage(string senderName, string message)
    {
        nameText.text = name;
        messageText.text = message;
    }
}
