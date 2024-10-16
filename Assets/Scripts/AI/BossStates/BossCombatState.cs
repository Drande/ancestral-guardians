using UnityEngine;

public class BossCombatState : BossState
{
    public override void EnterState(BossStateManager context)
    {
        context.LoadTarget();
        if(context.target == null) {
            context.SwitchState(context.idleState);
        }
    }

    public override void OnTriggerEnter2D(BossStateManager context, Collider2D other) {}

    public override void UpdateState(BossStateManager context)
    {
        if(!context.weapon.IsAttacking) {
            var direction = ((Vector2)context.transform.position).CalculateFourSideDirection(context.target.transform.position);
            context.LookAt(direction);
            context.weapon.transform.LookAt2D(context.target);
        }
        
        if(context.weapon.IsReady()) {
            context.weapon.Attack(context.layerMask, 10, () => {
                context.AnimateAttack();
            });
        }
    }
}