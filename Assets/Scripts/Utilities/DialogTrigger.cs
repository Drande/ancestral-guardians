using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogTrigger : DialogBase
{
    private void OnTriggerEnter2D(Collider2D other) {
        SceneDialog.Instance.DisplayMessageAt(transform.position, message, instant);
    }

    private void OnTriggerExit2D(Collider2D other) {
        SceneDialog.Instance.HideMessage();
    }
}
