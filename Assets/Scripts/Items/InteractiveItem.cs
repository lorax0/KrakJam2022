using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField]
    private bool canInteract = true;
    [SerializeField]
    private List<Collider> coll;
    [SerializeField]
    protected virtual ItemType type => default;

    public bool CanInteract { get => canInteract; set => canInteract = value; }
    public List<Collider> Collider => coll;
    public ItemType Type => type;

    public virtual void Interact()
    {
        Debug.Log("Interact");
    }
}