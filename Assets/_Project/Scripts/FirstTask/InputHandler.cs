using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";

    private Vector3 _movementDirection;

    public Vector3 GetMovementDirection() => _movementDirection;

    private void Update()
    {
        _movementDirection = new Vector3(Input.GetAxis(_horizontal), 0, Input.GetAxis(_vertical));
    }
}
