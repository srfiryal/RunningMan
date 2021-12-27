using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrailEmit : MonoBehaviour
{
    // Declare and/or init variable.
    private TrailRenderer trailRenderer;
    private float duration;
    private float timeStamp;

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        // Randomize trail emit.
        if (Time.time > timeStamp + duration)
        {
            duration = Random.Range(0.05f, 0.3f);
            timeStamp = Time.time;
            trailRenderer.emitting = !trailRenderer.emitting;
        }
    }
}
