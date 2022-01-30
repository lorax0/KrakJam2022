using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : InteractiveItem
{
    protected override ItemType type => ItemType.MapPart;

    public override void Interact()
    {
        Inventory.Instance.AddItem(this);
        gameObject.SetActive(false);
    }
}