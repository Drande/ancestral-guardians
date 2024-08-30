using System;
using UnityEngine;

public abstract class ChargedWeaponBase : MonoBehaviour {
    protected IChargedAttack[] attacks;
    public int AttackCount => attacks.Length;

    protected void Awake() {
        attacks = GetComponentsInChildren<IChargedAttack>();
    }

    public abstract void Attack(LayerMask layerMask, float attackPower, Action onChargeCompleted);
}