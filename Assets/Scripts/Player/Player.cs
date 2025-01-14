using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private PlayerMouseMovement mouseMovement;
    [SerializeField] private PlayerInput playerInput;
    
    [SerializeField] private PlayerCameraController cameraController;

    [SerializeField] private PlayerMovementController movementController;

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
