using UnityEngine;

public abstract class EnemyState {
    public abstract void EnterState(EnemyStateManager context);
    public abstract void UpdateState(EnemyStateManager context);
    public abstract void OnTriggerEnter2D(EnemyStateManager context, Collider2D other);
}