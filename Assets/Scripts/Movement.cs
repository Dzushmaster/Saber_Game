using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController _charController;
    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _gravityScale;
    [SerializeField] float _countJumps;
    Vector3 _moveDirection;
    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        _moveDirection = new Vector3(_movementSpeed * Input.GetAxis("Horizontal"), _moveDirection.y, _movementSpeed * Input.GetAxis("Vertical"));
        if (_charController.isGrounded)
            if (Input.GetButtonDown("Jump"))
            {
                _moveDirection.y = _jumpForce;
                _countJumps++;
            }
        _moveDirection.y = _moveDirection.y + Physics.gravity.y * _gravityScale * Time.deltaTime;
        _charController.Move(_moveDirection * Time.deltaTime);
    }
}
