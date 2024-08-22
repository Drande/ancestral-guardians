using UnityEngine;

public class Fragile : MonoBehaviour, IDamageable
{
    public void TakeDamage(int _)
    {
        Destroy(gameObject);
    }
}