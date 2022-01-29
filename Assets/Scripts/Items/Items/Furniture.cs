using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : InteractiveItem
{
    [SerializeField]
    private Animator anim;

    private bool isOpen = false;
    private bool isOpening = false;
    
    public override void Interact()
    {
        if (!CanInteract)
        {
            Debug.Log("cant interact!");
            return;
        }

        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        isOpen = true;
        anim.Play("Open");
    }

    private void Close()
    {
        isOpen = false;
        anim.Play("Close");
    }
}