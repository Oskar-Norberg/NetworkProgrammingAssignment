using Unity.Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class PlayerCameraController : NetworkBehaviour
{
    [SerializeField] private PlayerMouseMovement mouseMovement;

    [SerializeField] private float sensitivity = 1.0f;
    
    [SerializeField] private Transform playerRoot;
    [SerializeField] private Transform cameraPivotTransform;
    
    // Cinemachine
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private CinemachineThirdPersonFollow thirdPersonFollow;
    [SerializeField] private CinemachineThirdPersonAim thirdPersonAim;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        cinemachineCamera.enabled = IsOwner;
        thirdPersonFollow.enabled = IsOwner;
        thirdPersonAim.enabled = IsOwner;
    }

    private void Update()
    {
        Vector2 mouseVector = mouseMovement.GetMouseMovement();
        float y = sensitivity * mouseVector.x;
        float x = sensitivity * -mouseVector.y;
        
        // Rotate player/parent around y-axis.
        playerRoot.Rotate(0.0f, y, 0.0f);
        
        // Rotate camera-pivot around x-axis.
        cameraPivotTransform.Rotate(x, 0.0f, 0.0f);
    }
}
