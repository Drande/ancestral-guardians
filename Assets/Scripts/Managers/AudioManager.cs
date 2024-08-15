using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private Sound[] musicSounds, sfxSounds;
    [SerializeField] private AudioSource musicSource, sfxSource;
    [SerializeField] private AudioMixer masterMixer;
    private const string MusicVolumeKey = "MusicVolume";
    private const string SfxVolumeKey = "SfxVolume";
    private const string MasterVolumeKey = "MasterVolume";
    public bool IsMuted => MasterVolume == 0f;
    public delegate void MuteStateChanged(bool isMuted);
    public event MuteStateChanged OnMuteStateChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ApplySettings();
        OnMuteStateChanged?.Invoke(IsMuted);
        HandleSceneChange(SceneManager.GetActiveScene());
        SceneManager.activeSceneChanged += (previous, current) =>
        {
            if (previous.name != current.name) HandleSceneChange(current);
        };
    }

    public float MusicVolume
    {
        get => PlayerPrefs.GetFloat(MusicVolumeKey, 1.0f);
        set
        {
            PlayerPrefs.SetFloat(MusicVolumeKey, value);
            PlayerPrefs.Save();
            SetMusicVolume(value);
        }
    }

    public float SfxVolume
    {
        get => PlayerPrefs.GetFloat(SfxVolumeKey, 1.0f);
        set
        {
            PlayerPrefs.SetFloat(SfxVolumeKey, value);
            PlayerPrefs.Save();
            SetSfxVolume(value);
        }
    }

    public float MasterVolume
    {
        get => PlayerPrefs.GetFloat(MasterVolumeKey, 1.0f);
        set
        {
            PlayerPrefs.SetFloat(MasterVolumeKey, value);
            PlayerPrefs.Save();
            SetMasterVolume(value);
            OnMuteStateChanged?.Invoke(value == 0f);
        }
    }

    /// <summary>
    /// Subscribes a handler method to the mute state changed event.
    /// When subscribed, the handler will be invoked immediately with the current mute state.
    /// This allows for immediate feedback on the current mute status upon subscription.
    /// </summary>
    /// <param name="handler">The method to be invoked when the mute state changes.</param>
    public void SubscribeToMuteStateChanged(MuteStateChanged handler)
    {
        OnMuteStateChanged += handler;
        // Immediately invoke the handler with the current state
        handler?.Invoke(IsMuted);
    }

    /// <summary>
    /// Toggles the mute state by setting the master volume to either 0 (muted) or 1 (unmuted).
    /// It retrieves the current master volume from the audio mixer and toggles it accordingly.
    /// This method updates the mute state and invokes the corresponding event to notify subscribers of the change.
    /// </summary>
    public void ToggleMute()
    {
        if (masterMixer.GetFloat(MasterVolumeKey, out var volume))
        {
            Instance.MasterVolume = volume == 0f ? 0f : 1f;
        }
    }

    /// <summary>
    /// Applies the audio settings by updating the volume levels for sound effects (SFX), music, and the master volume.
    /// It retrieves the current volume settings from PlayerPrefs and sets them in the audio mixer.
    /// This method is typically called at the start to ensure that the audio settings are correctly applied when the game starts.
    /// </summary>
    public void ApplySettings()
    {
        // Apply the volume settings for sound effects
        SetSfxVolume(SfxVolume);

        // Apply the volume settings for music
        SetMusicVolume(MusicVolume);

        // Apply the master volume setting
        SetMasterVolume(MasterVolume);
    }

    public void SetMusicVolume(Slider slider) => MusicVolume = slider.value;
    public void SetSfxVolume(Slider slider) => SfxVolume = slider.value;
    public void SetMusicVolume(float volume) => SetVolume(MusicVolumeKey, volume);
    public void SetSfxVolume(float volume) => SetVolume(SfxVolumeKey, volume);
    public void SetMasterVolume(float volume) => SetVolume(MasterVolumeKey, volume);
    private void SetVolume(string key, float volume) => masterMixer.SetFloat(key, Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1.0f)) * 20);

    private void HandleSceneChange(Scene scene)
    {
        switch (scene.name)
        {
            default:
                break;
        }
    }

    /// <summary>
    /// Plays the music track with the specified name. If the track is found, it stops any currently playing music, 
    /// sets the track to loop, and then plays it. If the track is not found, logs a message.
    /// </summary>
    /// <param name="name">The name of the music track to play.</param>
    public void PlayMusic(string name)
    {
        var sound = Array.Find(musicSounds, s => s.name == name);
        if (sound != null)
        {
            musicSource.Stop();
            musicSource.loop = true;
            musicSource.clip = sound.audioClip;
            musicSource.Play();
        }
        else
        {
            Debug.Log($"Couldn't find music sound by name: '{name}'");
        }
    }

    /// <summary>
    /// Plays the sound effect with the specified name. If the sound effect is found, it sets the clip and plays it.
    /// If the sound effect is not found, logs a message.
    /// </summary>
    /// <param name="name">The name of the sound effect to play.</param>
    public void PlaySFX(string name)
    {
        var sound = Array.Find(Instance.sfxSounds, s => s.name == name);
        if (sound != null)
        {
            Instance.sfxSource.clip = sound.audioClip;
            Instance.sfxSource.Play();
        }
        else
        {
            Debug.Log($"Couldn't find sound effect by name: {name}");
        }
    }
}