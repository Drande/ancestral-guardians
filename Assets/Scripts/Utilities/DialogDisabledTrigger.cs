public class DialogDisabledTrigger : DialogBase
{
    private void OnDisable() {
        SceneDialog.Instance?.DisplayMessageAt(transform.position, message);
    }
}
