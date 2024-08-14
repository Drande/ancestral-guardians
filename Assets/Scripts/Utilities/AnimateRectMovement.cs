using System.Collections;
using UnityEngine;

public class AnimateRectMovement : MonoBehaviour
{
    [SerializeField] private Vector3 movement = Vector3.up;
    [SerializeField] private float arcHeight = 1;
    [SerializeField] private float duration = 0.25f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float elapsedTime;
    private RectTransform _rectTransform;

    private Vector3 Position
    {
        get => _rectTransform.anchoredPosition3D;
        set => _rectTransform.anchoredPosition3D = value;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        startPosition = Position;
        targetPosition = startPosition + movement;
        elapsedTime = 0f;
        StartCoroutine(MoveToPosition());
    }

    private IEnumerator MoveToPosition()
    {
        while (elapsedTime < duration)
        {
            // Calculate the proportion of the way to the target
            elapsedTime += Time.deltaTime;
            var t = elapsedTime / duration;

            // Control point for the Bézier curve
            Vector3 controlPoint = startPosition + new Vector3(0, arcHeight, 0);

            // Calculate the Bézier position using Unity's built-in Lerp
            Vector3 midpoint1 = Vector3.Lerp(startPosition, controlPoint, t);
            Vector3 midpoint2 = Vector3.Lerp(controlPoint, targetPosition, t);
            Position = Vector3.Lerp(midpoint1, midpoint2, t);

            // Wait until the next frame
            yield return null;
        }

        Position = targetPosition;
        gameObject.SetActive(false);
    }
}
