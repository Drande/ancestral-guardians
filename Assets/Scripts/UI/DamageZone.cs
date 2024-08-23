using System;
using System.Collections;
using UnityEngine;

public class DamageZone : MonoBehaviour, IAnimatable {
    [SerializeField] private GameObject indicator;
    [SerializeField] private Vector3 initialScale = Vector3.zero;
    private float elapsedTime;

    public void Animate(float duration, Action onCompleted) {
        gameObject.SetActive(true);
        StartCoroutine(ScaleTransition(duration, onCompleted));
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator ScaleTransition(float duration, Action onCompleted)
    {
        indicator.transform.localScale = initialScale;
        elapsedTime = 0;
        yield return new WaitForFixedUpdate();
        while(true) {
            elapsedTime += Time.fixedDeltaTime;
            var t = Mathf.Clamp01(elapsedTime / duration);
            if(t >= 1f) {
                indicator.transform.localScale = Vector3.one;
                break;
            } else {
                indicator.transform.localScale = Vector3.Lerp(initialScale, Vector3.one, t);
            }
            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
        onCompleted.Invoke();
    }
}