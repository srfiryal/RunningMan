using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour
{
    // Declare and/or init variable.
    [Header("Config")]
    [SerializeField] private Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
