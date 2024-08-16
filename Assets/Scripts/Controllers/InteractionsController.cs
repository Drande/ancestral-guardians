using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractionsController : MonoBehaviour {
    private IInteractable interactable;

    public void OnInteraction()
    {
        interactable?.Interact();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<IInteractable>(out var newInteractable)) {
            interactable?.OnLeave();
            interactable = newInteractable;
            interactable.OnEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.TryGetComponent<IInteractable>(out var abandonedInteractable)) {
            if(interactable == abandonedInteractable) {
                interactable = null;
            }
        }
    }
}
