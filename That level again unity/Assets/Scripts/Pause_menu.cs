using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public AudioSource audioSource;
    public GameObject HelpMessage;

    void Start()
    {
        PauseMenuUI.SetActive(false);
        HelpMessage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = !GameIsPaused;
            if (GameIsPaused)
                Pause();
            else
                Resume();
        }
            
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        HelpMessage.SetActive(false);
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void MuteSound()
    {
        audioSource.mute = !audioSource.mute;
    }

    public void Help()
    {
        HelpMessage.SetActive(true);
    }
}
