using UnityEngine;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        musicSlider.value = AudioManager.Instance.MusicVolume;
        sfxSlider.value = AudioManager.Instance.SfxVolume;
    }
}
