using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    // Start is called before the first frame update

    public AudioClip powerup_pickup;
    public AudioClip powerup_active;


    public AudioClip destroy;
    public AudioClip pass;
    public AudioClip start;


    public AudioClip crush;
    public AudioClip gameover;



    public AudioClip music;

    public AudioSource src;

    void Start()
    {
        src = GetComponent<AudioSource>();


        if (!Settings.Instance.Sound)
        {
            src.volume = 0;
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
 
}
