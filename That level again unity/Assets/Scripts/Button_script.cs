using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_script : MonoBehaviour
{
    SpriteRenderer buttonRenderer;

    public Sprite spriteUp;
    public Sprite spriteDown;
    //Game object de la porte
    public Door_script Door;
    int SceneIndex;

    void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonRenderer.sprite = spriteUp;
        SceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (SceneIndex != 3 && SceneIndex != 5 && SceneIndex != 7 && SceneIndex != 8 && SceneIndex != 9)
        {
            if (col.tag == "Player")
            {
                buttonRenderer.sprite = spriteDown;
                if (SceneIndex == 10)
                    Door.OpenDoor();
            }
        }
        else if (SceneIndex == 5)
            if (col.name == "DeadBody")
            {
                buttonRenderer.sprite = spriteDown;
                Door.OpenDoor();
            }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            buttonRenderer.sprite = spriteUp;
            if (SceneIndex == 10)
            {
                if (!GameObject.Find("Canvas").GetComponent<Pause_menu>().GameIsPaused)
                    Door.CloseDoor();
            }
        }
    }
}
