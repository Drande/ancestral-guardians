using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public override void EnterState(EnemyStateManager context)
    {
        context.LoadTarget();
    }

    public override void UpdateState(EnemyStateManager context)
    {
        context.LookAtTarget();
        if(context.InAttackRange()) {
            if(context.CanAttack()) {
                context.SwitchState(context.combatState);
            }
        } else {
            context.MoveTowardsTarget();
        }
    }

    public override void OnTriggerEnter2D(EnemyStateManager context, Collider2D other)
    {

    }
}