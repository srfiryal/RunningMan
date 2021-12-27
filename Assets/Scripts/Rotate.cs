using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Declare and/or init variable.
    [Header("Config")]
    [SerializeField] private float rotateSpeed = 1f;

    void Update()
    {
        transform.Rotate(0, 360 * rotateSpeed * Time.deltaTime, 0);
    }
}
