using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class DialogInteractable : MonoBehaviour, IInteractable {
    [SerializeField] private string message;
    [SerializeField] private bool instant;
    [SerializeField] private UnityEvent onEnter;
    [SerializeField] private UnityEvent onLeave;

    public void Interact()
    {
        SceneDialog.Instance.DisplayMessageAt(transform.position, message, instant);
    }

    public void OnEnter()
    {
        onEnter?.Invoke();
    }

    public void OnLeave()
    {
        onLeave?.Invoke();
    }
}