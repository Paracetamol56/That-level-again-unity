using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_event : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void LoadLevels()
    {
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
    }

    public void LoadAboutWebpage()
    {
        Application.OpenURL("https://github.com/Paracetamol56/That-level-again-unity");
    }

    public void QuitMenu()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
