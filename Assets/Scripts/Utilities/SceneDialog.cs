using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneDialog : MonoBehaviour
{
    public static SceneDialog Instance { get; private set; }
    [SerializeField] private GameObject dialogRef;
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private Vector3 dialogOffset;
    private const float delayBetweenLetters = 0.03f;
    private const float delay = 2f;
    private RectTransform dialogRect;

    private SceneDialog () {}

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        dialogRect = dialogRef.GetComponent<RectTransform>();
    }

    public void SetDialogPosition(Transform otherTransform) {
        Instance.dialogRect.anchoredPosition3D = otherTransform.position;
    }

    public void DisplayMessage(string message) {
        Instance.DisplayMessageAt(Instance.dialogRect.anchoredPosition3D, message);
    }

    public void DisplayInstantMessage(string message) {
        Instance.DisplayMessageAt(Instance.dialogRect.anchoredPosition3D, message, true);
    }
    
    public void HideMessage() {
        dialogRef.SetActive(false);
    }

    public void DisplayMessageAt(Vector3 position, string message, bool instant = false)
    {
        InitDialog(position);
        if(instant) {
            content.text = message;
            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRect);
        } else {
            StartCoroutine(WriteMessage(message));
        }
    }

    private IEnumerator WriteMessage(string message) {
        UpdateText(message);
        yield return new WaitForSeconds(delayBetweenLetters * message.Length);
        yield return new WaitForSeconds(delay);
        dialogRef.SetActive(false);
    }

    private void InitDialog(Vector3 position)
    {
        StopAllCoroutines();
        content.text = " ";
        LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRect);
        dialogRect.anchoredPosition3D = position + dialogOffset;
        dialogRef.SetActive(true);
    }

    private void UpdateText(string message)
    {
        StartCoroutine(Coroutines.WriteText(content, message, delayBetweenLetters, () => LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRect)));
    }
}
