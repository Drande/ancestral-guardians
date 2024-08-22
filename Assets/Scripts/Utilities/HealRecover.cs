using UnityEngine;

public class HealRecover : MonoBehaviour
{
    [SerializeField] private int fixedAmount;
    [SerializeField][Range(0, 1)] private float percentage;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            if(other.TryGetComponent<Health>(out var health)) {
                health.Heal(fixedAmount, percentage);
                gameObject.SetActive(false);
            }
        }
    }
}
