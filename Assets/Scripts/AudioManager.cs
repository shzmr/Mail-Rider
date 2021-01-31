using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class Sound
{
    [SerializeField]
    public AudioClip audioClip;
    [SerializeField]
    public string name;
}

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    private float soundVol = 1f;
    public Sound[] sounds;
    public static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    private AudioSource audioSource;
    public AudioSource[] engineSounds;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }


    public void SetSoundVol(float vol)
    {
        soundVol = vol;
    }

    public void SetMusicVol(float vol)
    {
        musicSource.volume = vol;
    }

    // RandomDepth should be between 0 and 1
    public void PlaySound(int soundToPlay, float volume = 0, float PitchRandDepth = 0)
    {
        audioSource.pitch = Random.Range(1 - PitchRandDepth, 1 + PitchRandDepth);
        audioSource.PlayOneShot(sounds[soundToPlay].audioClip, soundVol);
    }

    public IEnumerator SoundLoop(string soundName, int PerMin, float volume = 0.5f, float randPitchDepth = 0)
    {
        float baseRate = 60 / PerMin;

        while (true)
        {
            yield return new WaitForSeconds(baseRate + UnityEngine.Random.Range(baseRate * 0.8f, baseRate * 1.2f));
            PlaySound(soundName, 0.5f, 0.1f);
        }
    }

    public IEnumerator StartEngineSound(bool enable = true)
    {
        foreach (var engineSound in engineSounds)
        {
            if (enable)
            {
                engineSound.Play();
                yield return new WaitForSeconds(2);
            }
            else engineSound.Stop();
        }
    }

    public void PlayShotSound()
    {
        string soundToPlay = "Shot" + Random.Range(1, 4);
        PlaySound(soundToPlay, 0.5f, 0.1f);
    }

    public void PlaySound(string soundToPlay, float volume = 0.5f, float PitchRandDepth = 0)
    {
        AudioClip audioClip = sounds.First(x => x.name.ToLower() == soundToPlay.ToLower()).audioClip;

        audioSource.pitch = Random.Range(1 - PitchRandDepth, 1 + PitchRandDepth);
        audioSource.PlayOneShot(audioClip, volume);
    }
}
