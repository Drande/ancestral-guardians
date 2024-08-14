using UnityEngine;

public class Damage : MonoBehaviour {
    [SerializeField] private Tag target = Tag.Player;
    [SerializeField] private int power = 25;

    public void ApplyDamage(GameObject other) {
        if(!other.CompareTag(target.ToString())) return;
        if(other.TryGetComponent<Health>(out var health)) {
            health.TakeDamage(power);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ApplyDamage(other.gameObject);
    }

    private void OnCollisionStay2D(Collision2D other) {
        ApplyDamage(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        ApplyDamage(other.gameObject);
    }
}