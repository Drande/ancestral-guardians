using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputActionReference playerMovInput;
    public InputActionReference playerDashInput;
    public Rigidbody2D rBody;

    public float playerSpeed = 4; // Velocidad del jugador
    public float dashForce = 50f; // Fuerza del Dash
    public float dashDuration = 0.5f; // Duración del Dash
    public float dashCoolDown = 1f; // Tiempo que demora el jugador en pover volver a hacer un dash
    public float dashTimeLeft = 1f; // Tiempo restante del dash ejecutado
    
    private Vector2 playerInputValue; // Dirección en la que se mueve el jugador

    private bool canDash = true; // Chequeo si el jugador puede hacer el dash
    private bool isDashing = false; // Chequeo si el jugador está dasheando

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDashing)
        {
            Dash();
        }
    }
    void FixedUpdate()
    {
        playerInputValue = playerMovInput.action.ReadValue<Vector2>();
        
        if (!isDashing)
        {
            rBody.velocity = playerInputValue * playerSpeed;
        }       
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        playerInputValue = context.ReadValue<Vector2>();
        Debug.Log("Movement direction " + playerInputValue);
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && canDash == true && playerInputValue != Vector2.zero)
        {
            StartDashing();
            Debug.Log("Dash button pressed");
        }

    }


    public void StartDashing()
    {
        isDashing = true;
        canDash = false;
        dashTimeLeft = dashDuration;
    }

    private void Dash()
    {
        if (dashTimeLeft > 0)
        {
            rBody.velocity = playerInputValue * dashForce;
            dashTimeLeft -= Time.deltaTime;
        }

        else
        {
            isDashing = false;
            rBody.velocity = Vector2.zero;
            Invoke("ResetDash", dashCoolDown);
        }
        
    }

    private void ResetDash()
    {
        canDash = true;
    }

}
