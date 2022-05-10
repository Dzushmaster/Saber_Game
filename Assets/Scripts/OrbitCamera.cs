using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform pivot;
    float rotSpeed = 4.5f ;
    private Vector3 _offset; 
    // Start is called before the first frame update
    void Start()
    {
        _offset = target.position - transform.position;
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float _rotY = Input.GetAxis("Mouse X") * rotSpeed;
        target.Rotate(0, _rotY, 0);

        float _rotX = Input.GetAxis("Mouse Y")* rotSpeed;
        pivot.Rotate(_rotX, 0, 0);

        if (pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f)
            pivot.rotation = Quaternion.Euler(45f, 0, 0);

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotaion = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotaion * _offset);
        if (transform.position.y < target.position.y)
            transform.position = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z);
        transform.LookAt(target);
    }
}
