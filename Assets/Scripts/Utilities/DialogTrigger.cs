using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogTrigger : DialogBase
{
    [SerializeField] private Tag triggedBy = Tag.Player;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(triggedBy.ToString()))
            SceneDialog.Instance.DisplayMessageAt(transform.position, message, instant);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag(triggedBy.ToString()))
            SceneDialog.Instance.HideMessage();
    }
}
