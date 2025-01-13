using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{
    private Vector2 movement;

    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }

    public Vector2 GetMouseMovement()
    {
        return movement;
    }
}
