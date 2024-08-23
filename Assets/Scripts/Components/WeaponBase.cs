using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {
    protected IAttack[] attacks;
    public int AttackCount => attacks.Length;
    protected bool isReady = true;

    protected void Start() {
        attacks = GetComponentsInChildren<IAttack>();
    }

    public abstract void Attack(int index, LayerMask layerMask, float attackPower);
}