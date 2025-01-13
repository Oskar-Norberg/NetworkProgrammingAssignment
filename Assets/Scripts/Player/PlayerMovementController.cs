using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;

    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxSpeed;
    
    private void FixedUpdate()
    {
        Vector2 wishDir = playerInput.GetNormalizedInputDirection();
        Vector3 wishDir3D = new Vector3(wishDir.x, 0, wishDir.y);
        wishDir3D = transform.TransformDirection(wishDir3D);

        Vector3 force = Vector3.zero;
        force.x = wishDir3D.x;
        force.z = wishDir3D.z;

        force.x *= maxSpeed.CompareTo(Mathf.Abs(force.x));
        force.z *= maxSpeed.CompareTo(Mathf.Abs(force.z));

        if (Mathf.Abs(force.x) >= 0.0f && Mathf.Abs(force.z) >= 0.0f)
            rigidbody.AddForce(force * movementSpeed);

        
        force.x *= maxSpeed.CompareTo(Mathf.Abs(force.x));
        force.z *= maxSpeed.CompareTo(Mathf.Abs(force.z));
        
        if (Mathf.Abs(force.x) >= 0.0f && Mathf.Abs(force.z) >= 0.0f) rigidbody.AddForce(force * movementSpeed);
        
        rigidbody.angularVelocity = Vector3.zero;
    }
}
