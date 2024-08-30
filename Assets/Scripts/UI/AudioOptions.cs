using UnityEngine;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        musicSlider.SetValueWithoutNotify(AudioManager.Instance.MusicVolume);
        musicSlider.onValueChanged.AddListener((sliderValue) => {
            AudioManager.Instance.MusicVolume = sliderValue;
        });
        sfxSlider.SetValueWithoutNotify(AudioManager.Instance.SfxVolume);
        sfxSlider.onValueChanged.AddListener((sliderValue) => {
            AudioManager.Instance.SfxVolume = sliderValue;
        });
    }

    private void OnDestroy() {
        musicSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();
    }
}
