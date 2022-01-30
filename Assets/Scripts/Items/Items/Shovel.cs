using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : InteractiveItem
{
    protected override ItemType type => ItemType.Shovel;

    public override void Interact()
    {
        Inventory.Instance.AddItem(this);
        gameObject.SetActive(false);
    }
}