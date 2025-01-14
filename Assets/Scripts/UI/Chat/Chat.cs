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
            SendMessageRpc(OwnerClientId + "", "test text");
        }
    }

    [Rpc(SendTo.Everyone, Delivery = RpcDelivery.Reliable)]
    private void SendMessageRpc(string messageName, string messageText)
    {
        var newMessage = Instantiate(message, messageBox.transform);
        Message m = newMessage.GetComponent<Message>();
        m.SetMessage(messageName, messageText);
    }
}
