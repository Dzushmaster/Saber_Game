using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            transform.Rotate(10, 0, 0);
    }
}
