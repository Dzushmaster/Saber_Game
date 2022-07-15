using System;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            Destroy(other.gameObject);
    }
}
