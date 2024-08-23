using System.Linq;
using UnityEngine;

public class CircleAttack : MonoBehaviour, IAttack {
    [SerializeField] private float damageMultiplier = 1.0f;
    public float radius = 5f;

    public void PerformAttack(LayerMask layerMask, float attackPower)
    {
        var hits = GetCollisions(layerMask, radius);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.TryGetComponent<IDamageable>(out var target))
            {
                target.TakeDamage((int)(attackPower * damageMultiplier));
            }
        }
    }

    private RaycastHit2D[] GetCollisions(LayerMask layerMask, float raycastRadius) {
        return Physics2D.CircleCastAll(transform.position, raycastRadius, Vector3.zero, 0, layerMask)
            .Where(h => !h.collider.isTrigger).ToArray();
    }

    public bool IsTargetInRange(LayerMask layerMask)
    {
        return GetCollisions(layerMask, radius*0.5f).Length > 0;
    }
}