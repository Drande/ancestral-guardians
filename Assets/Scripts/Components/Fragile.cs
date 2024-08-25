using UnityEngine;

public class Fragile : MonoBehaviour, IDamageable
{
    public void TakeDamage(int _)
    {
        if(gameObject.TryGetComponent<Drops>(out var drops)) {
            drops.Drop();
        }
        Destroy(gameObject);
    }
}