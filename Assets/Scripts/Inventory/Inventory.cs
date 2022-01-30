using KrakJam2022;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoSingleton<Inventory>
{
    [SerializeField]
    private List<InteractiveItem> neededItems;
    [SerializeField]
    private List<InteractiveItem> items;
    [SerializeField]
    private InputActionReference input;

    protected override void Awake()
    {
        isPersistent = true;
        base.Awake();
    }

    public void AddItem(InteractiveItem item)
    {
        if (items.Contains(item))
        {
            Debug.Log($"has same item: {item.name}!");
            return;
        }

        items.Add(item);
        if (HasWholeMap())
        {
            Debug.LogError("Run puzzle mini game!");
        }
    }

    private bool HasWholeMap()
    {
        int mapPartCount = items.Where(t => t.Type.Equals(ItemType.MapPart)).Count();
        bool hasWholeMap = mapPartCount == Globals.mapParts;
        return hasWholeMap;
    }
}