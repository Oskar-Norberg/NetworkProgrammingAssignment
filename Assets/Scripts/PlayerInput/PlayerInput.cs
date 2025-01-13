using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 wishDir;

    private void Update()
    {
        wishDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public Vector2 GetNormalizedInputDirection()
    {
        return wishDir.normalized;
    }
}
