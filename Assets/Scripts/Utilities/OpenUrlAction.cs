using UnityEngine;
using UnityEngine.UI;

public class OpenUrlAction : MonoBehaviour
{
    [SerializeField] private string url;
    private Button button;

    private void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenUrl);
    }

    private void OpenUrl()
    {
        Application.OpenURL(url);
    }

    private void OnDestroy() {
        button.onClick.RemoveListener(OpenUrl);
    }
}