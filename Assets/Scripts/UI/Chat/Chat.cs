using TMPro;
using Unity.Netcode;
using UnityEngine;

public class Chat : NetworkBehaviour
{
    [SerializeField] private GameObject message;
    [SerializeField] private GameObject messageBox;
    
    [SerializeField] private TMP_InputField inputField;
    
    public delegate void OnMessageSent();
    public event OnMessageSent onMessageSent;

    public void EnableInputField()
    {
        inputField.gameObject.SetActive(true);
        inputField.ActivateInputField();
    }

    public void DisableInputField()
    {
        inputField.gameObject.SetActive(false);
        inputField.DeactivateInputField();
    }

    private void OnEnable()
    {
        inputField.onSubmit.AddListener(SendMessageCallback);
    }

    private void OnDisable()
    {
        inputField.onSubmit.RemoveListener(SendMessageCallback);
    }

    private void SendMessageCallback(string text)
    {
        onMessageSent?.Invoke();
        SendMessageToServerRpc(inputField.text);
        inputField.text = "";
    }

    [Rpc(SendTo.Server, Delivery = RpcDelivery.Reliable)]
    private void SendMessageToServerRpc(string messageText, RpcParams rpcParams = default)
    {
        if (!IsServer || !IsHost) return;

        ulong playerId = rpcParams.Receive.SenderClientId;
        string messageName = PlayerManager.Instance.GetPlayer(playerId).playerName.Value + "";
        
        SendMessageToEveryoneRpc(messageName, messageText);
    }

    [Rpc(SendTo.Everyone, Delivery = RpcDelivery.Reliable)]
    private void SendMessageToEveryoneRpc(string messageName, string messageText)
    {
        var newMessage = Instantiate(message, messageBox.transform);
        Message m = newMessage.GetComponent<Message>();
        m.SetMessage(messageName, messageText);
    }
}
