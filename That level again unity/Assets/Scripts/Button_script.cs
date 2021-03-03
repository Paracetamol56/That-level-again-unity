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
        switch (SceneIndex)
        {
            case 1:
            case 2:
            case 4:
            case 6:
            case 10:
                if (col.tag == "Player")
                {
                    buttonRenderer.sprite = spriteDown;
                    if (SceneIndex == 10)
                        Door.OpenDoor();
                }
                break;
            case 5:
                if (col.name == "DeadBody")
                {
                    buttonRenderer.sprite = spriteDown;
                    Door.OpenDoor();
                }
                break;
            case 11:
                if (col.name == "Block")
                {
                    buttonRenderer.sprite = spriteDown;
                    Door.OpenDoor();
                }
                break;
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
