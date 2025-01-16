using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour, IUpdateable
{
    [SerializeField] private PlayerMouseMovement mouseMovement;
    [SerializeField] private PlayerInput playerInput;
    
    [SerializeField] private PlayerCameraController cameraController;

    [SerializeField] private PlayerMovementController movementController;
    
    public static Player Instance { get; private set; }
    
    public NetworkVariable<FixedString32Bytes> playerName = new NetworkVariable<FixedString32Bytes>(
        "NAME_NOT_INITIALIZED", 
        NetworkVariableReadPermission.Everyone, 
        NetworkVariableWritePermission.Owner);
    
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
