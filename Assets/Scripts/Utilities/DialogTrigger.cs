using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private string message;
    [SerializeField] private bool instant;

    private void OnTriggerEnter2D(Collider2D other) {
        SceneDialog.Instance.DisplayMessageAt(transform.position, message, instant);
    }
}
