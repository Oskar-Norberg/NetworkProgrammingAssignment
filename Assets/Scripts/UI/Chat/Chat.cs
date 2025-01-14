using Unity.Netcode;
using UnityEngine;

public class Chat : NetworkBehaviour
{
    [SerializeField] private GameObject message;
    
    [SerializeField] private GameObject messageBox;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessageToServerRpc("test text");
        }
    }

    [Rpc(SendTo.Server, Delivery = RpcDelivery.Reliable)]
    private void SendMessageToServerRpc(string messageText, RpcParams rpcParams = default)
    {
        if (!IsServer || !IsHost) return;

        ulong playerId = rpcParams.Receive.SenderClientId;
        string messageName = PlayerManager.Instance.GetPlayer(playerId).name;
        
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
