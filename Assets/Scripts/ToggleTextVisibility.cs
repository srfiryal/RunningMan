using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTextVisibility : MonoBehaviour
{
    // Declare and/or init variable.
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            text.gameObject.SetActive(false);
        }
    }
}
