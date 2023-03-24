using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public bool turnInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;

        turnInput = false;
    }

    private void Update()
    {
        
    }

    public void OnTurnInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            turnInput = true;
        }

        if(context.canceled)
        {
            turnInput = false;
        }
    }
}
