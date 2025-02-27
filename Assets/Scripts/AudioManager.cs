using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioMixer audioMixer;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public void PlayMusic(string musicName)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + musicName);
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(string sfxName)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/SFX/" + sfxName);
        sfxSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume) { audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20); }
    public void SetSFXVolume(float volume) { audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20); }
}