using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    //[SerializeField] GameObject gm;
    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _gravityScale;
    [SerializeField] float _maxCountJumps;
    [SerializeField] float _dashTime;
    [SerializeField] float _dashSpeed;
    Vector3 _moveDirection;
    float _countJumps;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float yStore = _moveDirection.y;
        _moveDirection = (transform.forward * Input.GetAxis("Vertical") * _movementSpeed + transform.right * Input.GetAxis("Horizontal") * _movementSpeed);
        _moveDirection.y = yStore;
        if (Input.GetButtonDown("Jump") && _countJumps+1 < _maxCountJumps)
        {
            _moveDirection.y = _jumpForce;
            _countJumps++;
        }
        transform.position += _moveDirection;
        // if (_charController.isGrounded)
        //     _countJumps = 0;
        // if (Input.GetKeyDown(KeyCode.LeftShift))
        //     StartCoroutine(Dash());
        // _moveDirection.y = _moveDirection.y + Physics.gravity.y * _gravityScale * Time.deltaTime;
        //_charController.Move(_moveDirection * Time.deltaTime);
    }
    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + _dashTime)
        {
            _moveDirection.y = 0;
            // _charController.Move(new Vector3(_moveDirection.x * _dashSpeed * Time.deltaTime, 0, _moveDirection.z * _dashSpeed * Time.deltaTime));
            yield return null;
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     if(other.CompareTag("Convayor"))
    //         _charController.Move(Vector3.MoveTowards(_charController.transform.position, ))
    // }
}