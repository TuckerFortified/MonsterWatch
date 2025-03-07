using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audioSource;

    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
