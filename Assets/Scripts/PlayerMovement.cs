using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Declare and/or init variable.
    [Header("Config")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;
    private bool isJumpPressed;
    private float jumpTimer;
    private float jumpGracePeriod = 0.2f;
    private bool isGameFinished;
    private bool isGameStarted = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();   
    }

    void Update()
    {
        horizontalInput = 1;

        // GroundChecks prevent player from getting stuck after jump landing.
        isGrounded = false;
        foreach (var groundCheck in groundChecks)
        {
            if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                isGrounded = true;
                break;
            }
        }

        // Check if player is on ground. If they do, disable gravity, if they don't, then manually adds gravity.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // WallChecks prevent player from getting stuck when running onto a walls.
        var isBlocked = false;
        foreach (var wallcheck in wallChecks)
        {
            if (Physics.CheckSphere(wallcheck.position, 0.01f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                isBlocked = true;
                break;
            }
        }

        // Check if character is not blocked, if they do, the player cannot move.
        if (isGameStarted && !isGameFinished && !isBlocked)
        {
            // Move character.
            characterController.Move(new Vector3(horizontalInput * movementSpeed, 0, 0) * Time.deltaTime);
        }

        isJumpPressed = Input.GetButtonDown("Jump");

        // Enable jumping
        if (isGameStarted && !isGameFinished && isGrounded && (isJumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2 * gravity);
            jumpTimer = -1;
        }

        // If jump button pressed for the first time, the game starts.
        if (isJumpPressed)
        {
            isGameStarted = true;
        }

        // Vertical velocity.
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player bumps into an object with "Finish" tag, the game will be marked as finished.
        if (other.gameObject.CompareTag("Finish"))
        {
            isGameFinished = true;
        }
    }
}
