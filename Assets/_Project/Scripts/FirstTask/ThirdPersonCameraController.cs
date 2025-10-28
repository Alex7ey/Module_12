using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxAngleRotation;

    private Vector3 _offSetPosition;
    private Vector2 _currentRotation;

    private string _horizontalAxis = "Mouse X";
    private string _verticalAxis = "Mouse Y";

    private void Awake()
    {
        _offSetPosition = transform.position - _followTarget.position;
    }

    private void LateUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        _currentRotation += GetInput();
        Quaternion currentAngle = Quaternion.Euler(0, _currentRotation.x, Mathf.Clamp(_currentRotation.y, -_maxAngleRotation, 0f));
        transform.position = _followTarget.position + (currentAngle * _offSetPosition);
        transform.LookAt(_followTarget);
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw(_horizontalAxis), Input.GetAxisRaw(_verticalAxis));
    }
}
