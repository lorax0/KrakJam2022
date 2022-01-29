using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField]
    private bool canInteract = true;
    [SerializeField]
    private Collider coll;

    public bool CanInteract { get => canInteract; set => canInteract = value; }
    public Collider Collider => coll;

    public virtual void Interact()
    {
        Debug.Log("D");
    }
}