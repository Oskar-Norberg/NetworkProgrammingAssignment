using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private PlayerMouseMovement mouseMovement;
    [SerializeField] private PlayerInput playerInput;
    
    [SerializeField] private PlayerCameraController cameraController;

    [SerializeField] private PlayerMovementController movementController;

    
    // TODO: Set this via UI somehow.
    // Make a proper set name system. Where the player tries a name, sends it to the server and gets back whether or not it is taken.
    private string name = "test name";
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        mouseMovement.enabled = IsOwner;
        playerInput.enabled = IsOwner;
        
        cameraController.enabled = IsOwner;
        
        movementController.enabled = IsOwner;
    }
}
