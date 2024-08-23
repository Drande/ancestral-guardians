using UnityEngine;

public class EnemyCombatState : EnemyState
{
    public override void EnterState(EnemyStateManager context)
    {
        context.LoadTarget();
    }

    public override void OnTriggerEnter2D(EnemyStateManager context, Collider2D other) {}

    public override void UpdateState(EnemyStateManager context)
    {
        context.LookAtTarget();
        if(context.InAttackRange()) {
            if(context.CanAttack()) {
                context.Attack();
            }
        } else {
            context.SwitchState(context.moveState);
        }
    }
}