using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable {
    [SerializeField] private int maxHealth = 100;
    private int health;
    public event Action<float> OnRateChanged;
    [SerializeField] private float inmmunityCooldown = 0;
    private bool hasInmunity;
    public event Action OnDeath;

    private void Awake() {
        health = maxHealth;
    }

    private void Start() {
        NotifyRate();
    }

    public void TakeDamage(int amount) {
        if(hasInmunity) return;
        if(health == 0) return;
        SceneTextPool.Instance.DisplayAt(transform.position, amount.ToString());
        health = Math.Clamp(health - amount, 0, maxHealth);
        NotifyRate();
        if(health == 0) {
            Die();
        } else {
            hasInmunity = true;
            Invoke(nameof(ResetInmunity), inmmunityCooldown);
        }
    }

    private void Die() {
        if(OnDeath == null) {
            Destroy(gameObject);
        } else {
            OnDeath.Invoke();
        }
        OnDeath = null;
        if(gameObject.TryGetComponent<Drops>(out var drops)) {
            drops.Drop();
        }
    }

    private void ResetInmunity()
    {
        hasInmunity = false;
    }

    private void NotifyRate()
    {
        OnRateChanged?.Invoke(health/(float)maxHealth);
    }

    public void Heal(int fixedAmount, float percentage)
    {
        int amount = fixedAmount + (int)(percentage*maxHealth);
        SceneTextPool.Instance.DisplayAt(transform.position, amount.ToString(), SceneTextStyle.Heal);
        health = Math.Clamp(health + amount, 0, maxHealth);
        NotifyRate();
    }
}