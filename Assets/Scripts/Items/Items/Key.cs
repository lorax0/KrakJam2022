using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractiveItem
{
    protected override ItemType type => ItemType.Key;

    public override void Interact()
    {
        Inventory.Instance.AddItem(this);
        gameObject.SetActive(false);
    }
}