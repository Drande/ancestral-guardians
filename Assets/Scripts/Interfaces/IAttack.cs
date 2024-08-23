using UnityEngine;

public interface IAttack {
    bool IsTargetInRange(LayerMask layerMask);
    void PerformAttack(LayerMask layerMask, float attackPower); 
}
