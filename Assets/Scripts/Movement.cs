using UnityEngine;
public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallSpeed;
    [SerializeField] private int maxCountJump;
    [SerializeField] private float dashSpeed;
    public Transform camera;
    private float turnSmoothVelocity;
    private float turnSmoothTime = 0.1f;
    private int countJump;
    private float playerSize = 2;
    private float groundDrag = 1;
    private bool grounded;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        grounded = true;
    }
    void Update()
    {
        rb.AddForce(Physics.gravity * fallSpeed, ForceMode.Force);
        grounded = Physics.Raycast(transform.position, Vector3.down, playerSize * 0.5f + 0.2f);
        InputMove();
        SpeedControl();
        if (grounded)
        {
            rb.drag = groundDrag;
            countJump = 0;
        }
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        MovePlayer(angle);
    }

    private void InputMove()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && maxCountJump > countJump + 1)
        {
            countJump++;
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            Dash();
    }

    private void MovePlayer(float angle)
    {
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (moveDirection.magnitude >= .1f)
        {
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Dash()
    {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
        rb.AddForce(moveDir.normalized * dashSpeed * 10f, ForceMode.Impulse);
    }
}