using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWinSoundScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetString("Score") != "You Lose!")
        {
            audioSource.Play();

        }
        else
        {
            audioSource.clip = clip; 
            audioSource.Play();
        }
    }


    void Update()
    {
        
    }
}
