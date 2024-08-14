using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference playerMovInput;
    public InputActionReference playerDashInput;

    public int playerSpeed = 4;
    public Rigidbody2D rBody;
    private Vector2 playerInputValue;


    public void OnMovement(InputAction.CallbackContext context)
    {
        playerInputValue = context.ReadValue<Vector2>();
        Debug.Log(playerInputValue);
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        Debug.Log("Dash button pressed");
    }

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        playerInputValue = playerMovInput.action.ReadValue<Vector2>();

        rBody.velocity = playerInputValue * playerSpeed;
    }

}
