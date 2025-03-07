using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{

    public static int searchesLeft;
    public static int guessesLeft;
    public static bool makingGuess;
    public static string monsterGuess;
    public static string tileGuess;
    public static bool madeTileGuess;

    public TextMeshProUGUI text;
    public GameObject okayButton;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject dialogueBox;
    public TextMeshProUGUI searchText;
    public TextMeshProUGUI guessesText;
    public GameObject scarySpiderButton;
    public GameObject shiveringSpiderButton;
    public GameObject spinyDragon;
    public GameObject peppyDragon;
    public GameObject psychicMoth;
    public GameObject friendlyMoth;

    public static bool inUI;

    public static bool mothGuessed;
    public static bool dragonGuessed;
    public static bool snakeGuessed;

    public AudioClip Radio;
    public AudioClip Click;
    public AudioClip Win;
    private AudioSource sounds;


    public Rigidbody2D radioRigidBody;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        searchesLeft = 25;
        inUI = false;
        text.text = "";
        okayButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        dialogueBox.SetActive(false);
        guessesLeft = 3;
        monsterGuess = "";
        tileGuess = "";
        madeTileGuess = false;
        scarySpiderButton.SetActive(false);
        shiveringSpiderButton.SetActive(false);
        spinyDragon.SetActive(false);
        peppyDragon.SetActive(false);
        psychicMoth.SetActive(false);
        friendlyMoth.SetActive(false);
        mothGuessed = false;
        dragonGuessed = false;
        snakeGuessed = false;
        sounds = gameObject.GetComponent<AudioSource>();
    }
    

    
    public void YesButton ()
    {
        radioRigidBody.AddForce((new Vector2(0, 100) * 20) / (searchesLeft + 1));
        float rand = Random.Range(0, 4);
        if (rand >= 3)
        {
            radioRigidBody.AddTorque(300 / (searchesLeft + 1));
        }
        else
        {
            radioRigidBody.AddTorque(-300 / (searchesLeft + 1));
        }
        sounds.clip = Radio;
        sounds.Play();


        if (!MicrophoneScript.makingGuess)
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            text.text = TileScript.tileInfo;
            okayButton.SetActive(true);
            searchesLeft -= 1;
        }
        else
        {
            text.text = "Select where you believe a monster is hiding.";
            yesButton.SetActive(false);
            noButton.SetActive(false);
            makingGuess = true;
        }
        
    }

    public void NoButton ()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
        dialogueBox.SetActive(false);
        okayButton.SetActive(false);
        text.text = "";
        text.fontSize = 45;
        inUI = false;
        MicrophoneScript.makingGuess = false;
        sounds.clip = Click;
        sounds.Play();
    }


    public void MonsterButton (string monster)
    {
        scarySpiderButton.SetActive(false);
        shiveringSpiderButton.SetActive(false);
        spinyDragon.SetActive(false);
        peppyDragon.SetActive(false);
        psychicMoth.SetActive(false);
        friendlyMoth.SetActive(false);  

        sounds.clip = Radio;
        sounds.Play();

        radioRigidBody.AddForce((new Vector2(0, 100) * 20) / (searchesLeft + 1));
        float rand = Random.Range(0, 4);
        if (rand >= 3)
        {
            radioRigidBody.AddTorque(300 / (searchesLeft + 1));
        }
        else
        {
            radioRigidBody.AddTorque(-300 / (searchesLeft + 1));
        }
        

        monsterGuess = monster;
        if (monsterGuess == tileGuess)
        {
            

            if (monsterGuess == "PSYCHIC MOTH")
            {
                mothGuessed = true;
                sounds.clip = Win;
                sounds.Play();
            }
            else if (monsterGuess == "SPINY DRAGON")
            {
                dragonGuessed = true;
                sounds.clip = Win;
                sounds.Play();
            }
            else if (monsterGuess == "MAGMA SNAKE")
            {
                snakeGuessed = true;
                sounds.clip = Win;
                sounds.Play();
            }

            text.text = "Amazing Boss! We found the monster and safely delt with it.";
            okayButton.SetActive(true);
            MicrophoneScript.makingGuess = false;
            makingGuess = false;
            madeTileGuess = false;
            monsterGuess = "";
            tileGuess = "";

            if (mothGuessed && dragonGuessed && snakeGuessed)
            {
                float scoring = (searchesLeft + (guessesLeft + 3 * 5) ) * 1000;
                PlayerPrefs.SetString("Score", "You Win! | Score: " + scoring.ToString());
                SceneManager.LoadScene(2);
            }

        }
        else
        {
            guessesLeft -= 1;
            text.text = "Sorry Boss, we couldn't find any monster nests there.";
            okayButton.SetActive(true);

            if (tileGuess != "NONE")
            {
                text.text = "Boss! We found the nest, but it was the wrong monster. We we're underprepared so we couldn't remove it. Try again!";
                text.fontSize = 36;
            }

            MicrophoneScript.makingGuess = false;
            makingGuess = false;
            madeTileGuess = false;
            monsterGuess = "";
            tileGuess = "";

            if (guessesLeft == 0)
            {
                PlayerPrefs.SetString("Score", "You Lose!");
                SceneManager.LoadScene(2);
            }
        }
    }


    private void Update()
    {
        /* Seth Note: I added this in just to allow the user to restart the game without
        having to alt-F4 if something ends up glitching in the game
        */
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        searchText.text = searchesLeft.ToString();
        guessesText.text = guessesLeft.ToString();

        if (madeTileGuess == true)
        {
            MicrophoneScript.makingGuess = false;
            text.text = "Which monster is located here?";
            yesButton.SetActive(false);
            noButton.SetActive(false);
            scarySpiderButton.SetActive(true);
            shiveringSpiderButton.SetActive(true);
            spinyDragon.SetActive(true);
            peppyDragon.SetActive(true);
            psychicMoth.SetActive(true);
            friendlyMoth.SetActive(true);
        }
    }

}
