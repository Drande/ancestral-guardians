using UnityEngine;

public class Weapon : WeaponBase {
    public override void Attack(int index, LayerMask layerMask, float attackPower) {
        attacks[index].PerformAttack(layerMask, attackPower);
    }
}