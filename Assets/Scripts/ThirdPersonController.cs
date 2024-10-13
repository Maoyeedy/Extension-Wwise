using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RotationSpeed = 700f;

    private Rigidbody _rb;
    private Vector3 _moveDirection;
    private float _horizontalInput;
    private float _verticalInput;

    public bool InvertHorizontal;
    public bool InvertVertical;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var mainCameraYAngle = Camera.main.transform.rotation.eulerAngles.y;

        _horizontalInput = InvertHorizontal ? -Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal");
        _verticalInput = InvertVertical ? -Input.GetAxis("Vertical") : Input.GetAxis("Vertical");

        _moveDirection = Quaternion.Euler(0, mainCameraYAngle, 0) * new Vector3(_horizontalInput, 0, _verticalInput);
    }

    private void FixedUpdate()
    {
        // Calculate target rotation
        var targetRotation = Quaternion.LookRotation(_moveDirection);
        _rb.MoveRotation(Quaternion.RotateTowards(_rb.rotation, targetRotation, RotationSpeed * Time.fixedDeltaTime));

        // Move the character
        _rb.MovePosition(_rb.position + _moveDirection * MoveSpeed * Time.fixedDeltaTime);
        // MoveWithRigidbody();
    }

    private void MoveWithRigidbody()
    {
        _rb.velocity = new Vector3(
            MoveSpeed * _moveDirection.x,
            _rb.velocity.y,
            MoveSpeed * _moveDirection.z
        );
    }
}