using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private LayerMask attackLayer;
    public int playerSpeed = 4;
    private Rigidbody2D rBody;
    private Vector2 playerInputValue;
    private Vector2 lastInput = Vector3.down;
    private Vector2 previousInput;
    private int nextAttack = 0;
    private Coroutine comboResetCoroutine;
    private bool canAttack = true;
    private const float comboResetTime = 1.5f;
    private const float attackDelay = 0.25f;
    public float dashForce = 35f; 
    public float dashDuration = 0.1f; 
    public float dashCoolDown = 0.7f; 
    public float dashTimeLeft = 1f; 
    private bool canDash = true; 
    private bool isDashing = false; 
    private Vector2 PlayerDirection => lastInput.GetLastAxisDirection(previousInput);

    #region MonoBehaviour methods
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
        if (!isDashing)
        {
            rBody.velocity = playerInputValue * playerSpeed;
        }       
    }
    #endregion

    #region InputListeners
    public void OnMovement(InputAction.CallbackContext context)
    {
        playerInputValue = context.ReadValue<Vector2>();
        if (playerInputValue != Vector2.zero)
        {
            previousInput = lastInput;
            lastInput = playerInputValue;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && canDash == true && playerInputValue != Vector2.zero)
        {
            StartDashing();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!canAttack) return;
        if (comboResetCoroutine != null)
            StopCoroutine(comboResetCoroutine);
        canAttack = false;
        weapon.transform.rotation = Quaternion.Euler(0, 0, PlayerDirection.ToRotationAngle());
        weapon.Attack(nextAttack, attackLayer, 10);
        nextAttack = (nextAttack + 1) % weapon.AttackCount;
        StartCoroutine(AttackCooldown());
        comboResetCoroutine = StartCoroutine(ResetComboCoroutine());
    }
    #endregion

    private IEnumerator ResetComboCoroutine()
    {
        yield return new WaitForSeconds(comboResetTime);
        ResetCombo();
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    private void ResetCombo()
    {
        nextAttack = 0;
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
