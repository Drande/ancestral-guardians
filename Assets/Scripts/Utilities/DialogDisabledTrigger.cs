using Unity.VisualScripting;

public class DialogDisabledTrigger : DialogBase
{
    private void OnDisable() {
        if(!SceneDialog.Instance.IsDestroyed()) {
            SceneDialog.Instance?.DisplayMessageAt(transform.position, message);
        }
    }
}
