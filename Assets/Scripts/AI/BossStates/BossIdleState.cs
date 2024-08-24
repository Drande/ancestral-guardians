using UnityEngine;

public class BossIdleState : BossState
{
    public override void EnterState(BossStateManager context)
    {

    }

    public override void UpdateState(BossStateManager context)
    {

    }

    public override void OnTriggerEnter2D(BossStateManager context, Collider2D other)
    {
        if(other.CompareTag("Player")) {
            context.SwitchState(context.combatState);
        }
    }
}