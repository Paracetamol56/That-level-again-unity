using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_menu_event : MonoBehaviour
{
    public Button[] Buttons;

    private void Start()
    {
        int PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        int CurrentButtonLevel = 0;
        foreach (Button iButton in Buttons)
        {
            if (CurrentButtonLevel <= PlayerLevel)
            {
                iButton.interactable = true;
            }
            else
            {
                iButton.interactable = false;
            }
            ++ CurrentButtonLevel;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void LoadLavel(int level)
    {
        SceneManager.LoadScene(level + 1, LoadSceneMode.Single);
    }

    public void ResetProgression()
    {
        PlayerPrefs.DeleteKey("PlayerLevel");
        Start();
    }
}
