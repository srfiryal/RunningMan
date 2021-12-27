using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Declare and/or init variable.
    [Header("Config")]
    [SerializeField] private Transform target;

    private Vector3 offset;

    private 
    void Start()
    {
        offset = transform.position - target.position;   
    }

    void Update()
    {
        // Gives smooth camera movement.
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 4, target.position.z) + offset, Time.deltaTime * 3);
    }
}
