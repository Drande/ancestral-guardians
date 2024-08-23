using System.Linq;
using UnityEngine;

public class RectangleAttack : MonoBehaviour, IAttack {
    [SerializeField] private float damageMultiplier = 1.0f;
    [SerializeField] protected Vector2 size = Vector2.one;
    [SerializeField] private string attackSfx;
    private Vector2 checkSize;
    private Vector2 OriginPosition => new(transform.position.x + size.x*transform.right.x/2, transform.position.y + size.y*transform.right.y);

    private void Awake() {
        checkSize = new Vector2(size.x/2, size.y/2);
    }

    public void PerformAttack(LayerMask layerMask, float attackPower)
    {
        AudioManager.Instance.PlaySFX(attackSfx);
        var hits = GetCollisions(layerMask, size);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.TryGetComponent<IDamageable>(out var target))
            {
                target.TakeDamage((int)(attackPower * damageMultiplier));
            }
        }
    }

    private RaycastHit2D[] GetCollisions(LayerMask layerMask, Vector2 raycastSize) {
        var angle = ((Vector2)transform.right).ToRotationAngle();
        return Physics2D.BoxCastAll(OriginPosition, raycastSize, angle, transform.right, 0, layerMask)
            .Where(h => !h.collider.isTrigger).ToArray();
    }

    public bool IsTargetInRange(LayerMask layerMask)
    {
        return GetCollisions(layerMask, checkSize).Length > 0;
    }
}