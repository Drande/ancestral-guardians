using UnityEngine;

public class BossStateManager : MonoBehaviour {
    private BossState currentState;
    public BossIdleState idleState = new();
    public BossCombatState combatState = new();
    public Transform target;
    public LayerMask layerMask;     // Layer mask to filter which objects are hit by the raycast
    public ChargedWeapon weapon;
    private Animator animator;
    private Vector2 lastDirection;

    private void Start() {
        animator = GetComponent<Animator>();
        currentState = idleState;
    }

    private void Update() {
        currentState.UpdateState(this);
    }

    public void SwitchState(BossState newState) {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void LookAt(Vector2 direction) {
        if(direction == lastDirection) return;
        lastDirection = direction;
        animator.SetFloat("speed_x_f", direction.x*0.1f);
        animator.SetFloat("speed_y_f", direction.y*0.1f);
    }

    public void StartCombat() {
        currentState = combatState;
    }

    public void LoadTarget() {
        target = GameObject.Find("Player")?.transform;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        currentState.OnTriggerEnter2D(this, other);
    }

    public void AnimateAttack()
    {
        animator.SetTrigger("attack_b");
    }
}