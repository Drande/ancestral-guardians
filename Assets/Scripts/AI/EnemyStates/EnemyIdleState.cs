using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public override void EnterState(EnemyStateManager context)
    {
        
    }

    public override void UpdateState(EnemyStateManager context)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager context, Collider2D other)
    {
        if(other.CompareTag("Player")) {
            if(context.InAttackRange()) {
                context.SwitchState(context.combatState);
            } else {
                context.SwitchState(context.moveState);
            }
        }
    }
}