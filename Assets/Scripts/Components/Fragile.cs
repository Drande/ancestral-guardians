using UnityEngine;

public class Fragile : MonoBehaviour, IDamageable
{
    [SerializeField] private string breakSfx;
    public void TakeDamage(int _)
    {
        if(gameObject.TryGetComponent<Drops>(out var drops)) {
            drops.Drop();
        }
        AudioManager.Instance.PlaySFX(breakSfx);
        Destroy(gameObject);
    }
}