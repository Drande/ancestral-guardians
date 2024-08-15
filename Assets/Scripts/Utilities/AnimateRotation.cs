using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AnimateRotation : MonoBehaviour
{
    [SerializeField] private float startRotationZ;  // Initial Z rotation in degrees
    [SerializeField] private float degreesToRotate; // Degrees to rotate (can be positive or negative)
    [SerializeField] private float duration = 1f;   // Duration of the rotation
    [SerializeField] private UnityEvent OnCompleted;

    private void OnEnable()
    {
        // Start the rotation coroutine
        StartCoroutine(RotateOverTime(startRotationZ, degreesToRotate, duration));
    }

    private IEnumerator RotateOverTime(float startRotationZ, float degreesToRotate, float duration)
    {
        float elapsedTime = 0f;

        // Calculate the target rotation based on the initial rotation and the degrees to rotate
        float targetRotationZ = startRotationZ + degreesToRotate;

        // Set the initial rotation
        transform.localRotation = Quaternion.Euler(0, 0, startRotationZ);

        while (elapsedTime < duration)
        {
            // Calculate the proportion of time passed
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            // Interpolate the rotation along the Z axis
            float currentZRotation = Mathf.Lerp(startRotationZ, targetRotationZ, t);
            transform.localRotation = Quaternion.Euler(0, 0, currentZRotation);

            yield return null; // Wait until the next frame
        }

        // Ensure the final rotation is set
        transform.localRotation = Quaternion.Euler(0, 0, targetRotationZ);
        OnCompleted?.Invoke();
    }
}
