using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] private Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable() // When the gameobject attached with this script, this will run.
    {
        if(playerController == null)
        {
            playerController = new PlayerController();
            playerController.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        // HandleJumpInput
        // ...
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }
}
