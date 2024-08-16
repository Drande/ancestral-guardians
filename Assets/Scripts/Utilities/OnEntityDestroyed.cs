using UnityEngine;
using UnityEngine.Events;

public class OnEntityDestroyed : MonoBehaviour
{
    [SerializeField] private UnityEvent onDeath;

    private void OnDestroy() {
        onDeath?.Invoke();
    }
}
