using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController _charController;
    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _gravityScale;
    [SerializeField] float _countJumps;
    [SerializeField] float _maxCountJumps;
    [SerializeField] float _dashSpeed;
    Vector3 _moveDirection;
    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        //_moveDirection = new Vector3(_movementSpeed * Input.GetAxis("Horizontal"), _moveDirection.y, _movementSpeed * Input.GetAxis("Vertical"));
        float yStore = _moveDirection.y;
        _moveDirection = -( transform.forward * Input.GetAxis("Vertical") * _movementSpeed+ transform.right * Input.GetAxis("Horizontal") * _movementSpeed);
        //_moveDirection = _moveDirection.normalized * (-_movementSpeed);
        _moveDirection.y = yStore;
        if (Input.GetButtonDown("Jump") && _countJumps < _maxCountJumps)
        {
            _moveDirection.y = _jumpForce;
            _countJumps++;
        }
        if (_charController.isGrounded)
            _countJumps = 0;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveDirection = -(transform.forward * Input.GetAxis("Vertical") * _dashSpeed + transform.right * Input.GetAxis("Horizontal") * _dashSpeed);
            //_moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            //_moveDirection = _moveDirection.normalized * _dashSpeed;
            _moveDirection.y = yStore;
        }
        _moveDirection.y = _moveDirection.y + Physics.gravity.y * _gravityScale * Time.deltaTime;
        _charController.Move(_moveDirection * Time.deltaTime);
    }
}
