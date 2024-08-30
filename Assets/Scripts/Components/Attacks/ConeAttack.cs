using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class ConeAttack : MonoBehaviour, IAttack {
    [SerializeField] private float damageMultiplier = 1.0f;
    [SerializeField] protected float length = 5f;
    [SerializeField] private string attackSfx;
    [SerializeField] GameObject particle;
    [Range(1, 360)] public int angleRange = 150;

    public void PerformAttack(LayerMask layerMask, float attackPower)
    {
        AudioManager.Instance.PlaySFX(attackSfx);
        var hits = GetCollisions(layerMask, length);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.TryGetComponent<IDamageable>(out var target))
            {
                target.TakeDamage((int)(attackPower * damageMultiplier));
                Instantiate(particle, new Vector3(hit.point.x,hit.point.y,-5), Quaternion.identity);
            }
        }
    }

    private RaycastHit2D[] GetCollisions(LayerMask layerMask, float raycastLength) {
        return Physics2D.CircleCastAll(transform.position, raycastLength, transform.right, 0, layerMask)
            .Where(h => !h.collider.isTrigger)
            .Where(hit => IsPointInCone(hit.point)).ToArray();
    }

    private bool IsPointInCone(Vector2 point)
    {
        // Calculate the direction from the cone's origin to the point
        Vector2 directionToPoint = (point - (Vector2)transform.position).normalized;

        // Calculate the forward direction of the cone
        Vector2 coneDirectionNormalized = transform.right.normalized;

        // Calculate the dot product between the cone's forward direction and the direction to the point
        float dotProduct = Vector2.Dot(coneDirectionNormalized, directionToPoint);

        // Calculate the angle between the cone's forward direction and the direction to the point
        float angleToPoint = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        // Check if the angle is within the cone's angle
        return angleToPoint <= angleRange / 2;
    }

    public bool IsTargetInRange(LayerMask layerMask)
    {
        var count = GetCollisions(layerMask, length*0.5f).Length;
        return count > 0;
    }
}