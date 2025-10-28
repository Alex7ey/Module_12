using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;

    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    private void Update()
    {
        Vector3 input = GetInput();

        if (input != Vector3.zero)
        {
            Rotate(input);
        }
    }

    private void Rotate(Vector3 input)
    {
        Quaternion angle = Quaternion.Euler(transform.eulerAngles + input);
        float step = Time.deltaTime * _rotationSpeed;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, step);
    }

    private Vector3 GetInput()
    {
        return new Vector3(Input.GetAxisRaw(_verticalAxis), 0, -Input.GetAxisRaw(_horizontalAxis));
    }
}
