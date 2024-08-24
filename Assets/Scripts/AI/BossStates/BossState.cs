using UnityEngine;

public abstract class BossState {
    public abstract void EnterState(BossStateManager context);
    public abstract void UpdateState(BossStateManager context);
    public abstract void OnTriggerEnter2D(BossStateManager context, Collider2D other);
}