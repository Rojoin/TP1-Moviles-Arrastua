using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] public AudioClip button;
    [SerializeField] public AudioClip money;
    [SerializeField] public AudioClip crash;
    [SerializeField] public AudioClip mainMenu;
    [SerializeField] public AudioClip gamePlay;
    [SerializeField] public AudioClip EndGame;

   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void PlayButtonSound()
    {
        effectSource.PlayOneShot(button);
    }

    public void PlayCrashSound()
    {
        effectSource.PlayOneShot(crash);
    }

    public void PlayMoneySound()
    {
        effectSource.PlayOneShot(money);
    }

    public void PlayMainMenuMusic()
    {
        musicSource.clip = mainMenu;
        musicSource.Play();
    }

    public void PlayFinaleMusic()
    {
        musicSource.clip = EndGame;
        musicSource.Play();
    }

    public void PlayGameplayMusic()
    {
        musicSource.clip = gamePlay;
        musicSource.Play();
    }

    public AudioSource GetMusicSource()
    {
        return musicSource;
    }

    public void ToggleEffects()
    {
        effectSource.mute = !effectSource.mute;
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
}