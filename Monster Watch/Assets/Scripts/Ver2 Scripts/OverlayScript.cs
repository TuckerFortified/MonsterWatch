using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayScript : MonoBehaviour
{
    public GameObject overlay;

    private bool active;

    public AudioClip Click;
    public AudioSource sounds;

    void Start()
    {
        overlay.SetActive(false);
        active = false;
    }

    
    void Update()
    {
        if (active == true)
        {
            overlay.SetActive(true);
        }
        if (active == false)
        {
            overlay.SetActive(false);
        }

    }

    private void OnMouseDown()
    {
        if (!GameManagerScript.inUI && !overlay.activeInHierarchy)
        {
            active = true;
            Debug.Log("here");
            GameManagerScript.inUI = true;
            Debug.Log(overlay.activeInHierarchy);
            sounds.clip = Click;
            sounds.Play();
        }

        if (GameManagerScript.inUI && overlay.activeInHierarchy)
        {
            GameManagerScript.inUI = false;
            active = false;
            sounds.clip = Click;
            sounds.Play();
        }

    }
}
