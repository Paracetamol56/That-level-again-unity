using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_script : MonoBehaviour
{
    SpriteRenderer buttonRenderer;

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Door_script TheDoor;

    void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonRenderer.sprite = spriteUp;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            buttonRenderer.sprite = spriteDown;
            TheDoor.OpenDoor();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            buttonRenderer.sprite = spriteUp;
        }
    }
}
