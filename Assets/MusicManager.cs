using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoSingleton<MusicManager>
{



    public AudioClip music;
    public AudioClip powerUp;

    public AudioSource musicSource;
    public AudioSource powerUpSource;


    void Start()
    {

      

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.clip = music;


        powerUpSource = gameObject.AddComponent<AudioSource>();
        powerUpSource.loop = true;
        powerUpSource.pitch = 2.3f;
        powerUpSource.clip = powerUp;


        if (!Settings.Instance.Sound)
            SetSounds(0);

        musicSource.Play();

    }
    public void SetSounds(int value)
    {
        musicSource.volume = value;
        powerUpSource.volume = value;
    }
}
