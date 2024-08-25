using UnityEngine;

public class EnemyStateManager : MonoBehaviour {
    private EnemyState currentState;
    public EnemyIdleState idleState = new();
    public EnemyCombatState combatState = new();
    public EnemyMoveState moveState = new();
    public Transform target;
    [SerializeField] private float speed = 5;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ChargedWeapon weapon;
    [SerializeField] private float attackPower = 10;
    private Rigidbody2D rb;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        currentState = idleState;
    }

    private void Update() {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyState newState) {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void StartCombat() {
        currentState = combatState;
    }

    public void LoadTarget() {
        if(target == null) {
            target = GameObject.Find("Player")?.transform;
            if(target == null) {
                SwitchState(idleState);
            }
        }
    }

    public void LookAtTarget() {
        if(!weapon.IsAttacking && target != null) {
            transform.LookAt2DSnapped(target);
            weapon.transform.LookAt2D(target);
        }
    }

    public bool CanAttack() {
        return weapon.IsReady();
    }

    public void Attack() {
        weapon.Attack(layerMask, attackPower);
    }

    public void MoveTowardsTarget() {
        if(target == null) return;
        rb.velocity = Vector2.zero;

        // Calculate the direction to the target
        Vector2 direction = (target.position - transform.position).normalized;

        // Calculate the new position
        Vector2 newPosition = rb.position + speed * Time.deltaTime * direction;

        // Move the Rigidbody2D towards the target using MovePosition
        rb.MovePosition(newPosition);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        currentState.OnTriggerEnter2D(this, other);
    }

    internal bool InAttackRange()
    {
        return weapon.InRange(layerMask);
    }
}