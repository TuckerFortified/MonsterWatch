using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicrophoneScript : MonoBehaviour
{
    public static bool makingGuess;

    public TextMeshProUGUI text;
    public GameObject dialogueBox;
    public GameObject yesButton;
    public GameObject noButton;
    public AudioClip Click;
    public AudioSource sounds;

    void Start()
    {
        makingGuess = false;
    }

    
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!GameManagerScript.inUI)
        {
            GameManagerScript.inUI = true;
            makingGuess = true;
            text.text = "Would you like to make a guess as to where a monster is?";
            dialogueBox.SetActive(true);
            yesButton.SetActive(true);
            noButton.SetActive(true);
            sounds.clip = Click;
            sounds.Play();
        }
    }
}
