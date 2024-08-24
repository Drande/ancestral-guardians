using UnityEngine;

public class BossStateManager : MonoBehaviour {
    private BossState currentState;
    public BossIdleState idleState = new();
    public BossCombatState combatState = new();
    public Transform target;
    public LayerMask layerMask;     // Layer mask to filter which objects are hit by the raycast
    public ChargedWeapon weapon;

    private void Start() {
        currentState = idleState;
    }

    private void Update() {
        currentState.UpdateState(this);
    }

    public void SwitchState(BossState newState) {
        currentState = newState;
        currentState.EnterState(this);
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
}