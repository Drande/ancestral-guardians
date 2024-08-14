using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class Indicator : MonoBehaviour {
    protected Slider indicator;
    
    protected void UpdateIndicator(float rate) {
        indicator.value = rate;
    }
}