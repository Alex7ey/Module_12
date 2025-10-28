using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform _sourceDirection;
    [SerializeField] private float _velocityMultiplier;
    [SerializeField] private float _jumpForce;

    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";

    private Rigidbody _rigidbody;
    private Vector3 _directionMove;

    private bool _isMoving;
    private bool _isJumped;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _directionMove = new Vector3(Input.GetAxis(_horizontal), 0, Input.GetAxis(_vertical));

        if (_directionMove != Vector3.zero)
            _isMoving = true;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _isJumped = true;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            Move(_sourceDirection.transform.TransformDirection(_directionMove));

        if (_isJumped)
            Jump();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            _isGrounded = false;
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.AddForce(_velocityMultiplier * direction);
        _isMoving = false;
    }

    private void Jump()
    {
        _rigidbody.AddForce(_jumpForce * Vector3.up);
        _isJumped = false;
    }
}
