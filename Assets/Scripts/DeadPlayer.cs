using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{

    ///public GameObject Player;
    private bool hasEntered;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !hasEntered)
        {
            Destroy(gameObject);
            //Player.SetActive(false);
            //SceneManager.LoadScene(0);
            GameManager.instance.Respawn();
        }
    }

}
 