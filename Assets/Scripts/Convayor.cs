using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Convayor : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    public float speed;
    public CharacterController ch;

    private void Start()
    {
        ch = null;
    }

    private void FixedUpdate()
    {
        if(ch!= null)
            ch.transform.position = (Vector3.MoveTowards(ch.transform.position, endpoint.position, 0.001f) * speed);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(ch == null)
            ch = hit.controller;
    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
    }
}
