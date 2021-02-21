using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_script : MonoBehaviour
{
    Animator doorAnim;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        doorAnim.SetBool("Open", true);
    }

    public void CloseDoor()
    {
        doorAnim.SetBool("Open", false);
    }
}
