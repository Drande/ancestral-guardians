using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : Indicator {
    [SerializeField] private Health measurable;
    [SerializeField] private string target;

    private void OnEnable() {
        if(measurable == null) {
            measurable = GameObject.Find(target).GetComponent<Health>();
        }
        measurable.OnRateChanged += UpdateIndicator;
        indicator = GetComponent<Slider>();
    }

    private void OnDisable() {
        measurable.OnRateChanged -= UpdateIndicator;
    }
}