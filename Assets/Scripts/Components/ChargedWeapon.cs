using System;
using System.Linq;
using UnityEngine;

public class ChargedWeapon : ChargedWeaponBase {
    public bool IsAttacking { get; private set; } = false;

    public bool InRange(LayerMask layerMask) {
        return attacks.Any(a => a.IsTargetInRange(layerMask));
    }

    public bool IsReady() {
        if(IsAttacking) return false;
        return attacks.Any(a => a.IsReady());
    }

    public override void Attack(LayerMask layerMask, float attackPower, Action onChargeCompleted = null) {
        var attack = attacks.First(a => a.IsReady());
        IsAttacking = true;
        attack?.Charge(() => {
            IsAttacking = false;
            onChargeCompleted?.Invoke();
            attack.PerformAttack(layerMask, attackPower);
        });
    }
}