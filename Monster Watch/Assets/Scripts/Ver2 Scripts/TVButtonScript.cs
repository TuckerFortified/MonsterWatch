using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVButtonScript : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public AudioClip music5;
    public AudioClip music6;
    public AudioClip music7;
    public AudioClip music8;
    public AudioClip music9;
    public AudioClip music10;
    public AudioClip music11;
    public AudioClip music12;
    public AudioClip music13;

    private int musicCount;

    public Sprite TVOn;
    public Sprite TVOff;

    public SpriteRenderer spriteRenderer;

    private float timer;

    void Start()
    {
        musicCount = 1;
        timer = 0;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f) 
        {
            spriteRenderer.sprite = TVOn;
        }
    }

    private void OnMouseDown()
    {
        if (!GameManagerScript.inUI)
        {

            spriteRenderer.sprite = TVOff;
            timer = 0;

            musicCount += 1;
            if (musicCount > 12)
            {
                musicCount = 0;
            }

            if (musicCount == 0)
            {
                audioSource.clip = music12;
                audioSource.Play();
            }
            if (musicCount == 1)
            {
                audioSource.clip = music1;
                audioSource.Play();
            }
            if (musicCount == 2)
            {
                audioSource.clip = music2;
                audioSource.Play();
            }
            if (musicCount == 3)
            {
                audioSource.clip = music3;
                audioSource.Play();
            }
            if (musicCount == 4)
            {
                audioSource.clip = music4;
                audioSource.Play();
            }
            if (musicCount == 5)
            {
                audioSource.clip = music5;
                audioSource.Play();
            }
            if (musicCount == 6)
            {
                audioSource.clip = music6;
                audioSource.Play();
            }
            if (musicCount == 7)
            {
                audioSource.clip = music7;
                audioSource.Play();
            }
            if (musicCount == 8)
            {
                audioSource.clip = music8;
                audioSource.Play();
            }
            if (musicCount == 9)
            {
                audioSource.clip = music9;
                audioSource.Play();
            }
            if (musicCount == 10)
            {
                audioSource.clip = music10;
                audioSource.Play();
            }
            if (musicCount == 11)
            {
                audioSource.clip = music11;
                audioSource.Play();
            }
            if (musicCount == 12)
            {
                audioSource.clip = music12;
                audioSource.Play();
            }

        }
    }
}
