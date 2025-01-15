using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour, IUpdateable
{
    [SerializeField] private PlayerMouseMovement mouseMovement;
    [SerializeField] private PlayerInput playerInput;
    
    [SerializeField] private PlayerCameraController cameraController;

    [SerializeField] private PlayerMovementController movementController;
    
    public static Player Instance { get; private set; }
    
    // TODO: Set this via UI somehow.
    // Make a proper set name system. Where the player tries a name, sends it to the server and gets back whether or not it is taken.
    private new string name = "NAME_NOT_INITIALIZED";
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            Instance = this;
        }
        
        mouseMovement.enabled = IsOwner;
        playerInput.enabled = IsOwner;
        
        cameraController.enabled = IsOwner;
        
        movementController.enabled = IsOwner;
    }

    public void CustomUpdate(float deltaTime)
    {
        cameraController.CustomUpdate(deltaTime);
        movementController.CustomUpdate(deltaTime);
    }

    public void CustomFixedUpdate(float fixedDeltaTime)
    {
        cameraController.CustomFixedUpdate(fixedDeltaTime);
        movementController.CustomFixedUpdate(fixedDeltaTime);
    }
}
