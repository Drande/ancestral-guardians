using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : Indicator {
    [SerializeField] private Health measurable;

    private void OnEnable() {
        measurable.OnRateChanged += UpdateIndicator;
        indicator = GetComponent<Slider>();
    }

    private void OnDisable() {
        measurable.OnRateChanged -= UpdateIndicator;
    }
}