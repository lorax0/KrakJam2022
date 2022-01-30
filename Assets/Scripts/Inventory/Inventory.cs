using Cinemachine;
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
    [SerializeField] protected Camera camera;
    [SerializeField] protected Camera oldCamera;

    private bool finishedPuzzle = false;

    public bool FinishedPuzzle { get => finishedPuzzle; set => finishedPuzzle = value; }

    protected override void Awake()
    {
        isPersistent = true;
        base.Awake();
    }

    private void Start()
    {
        if (HasAnyNeededItem())
        {
            Debug.LogError($"END GAME");
            var endGame = FindObjectOfType<EndGame>();
            endGame.End();
        }
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
            this.oldCamera.gameObject.SetActive(false);
            this.camera.gameObject.SetActive(true);
        }
        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        if (HasAnyNeededItem() && finishedPuzzle)
        {
            Debug.LogError($"END GAME");
            var endGame = FindObjectOfType<EndGame>();
            endGame.End();
        }
    }

    public void RevertCameraSettings()
    {
        this.oldCamera.gameObject.SetActive(true);
        this.camera.gameObject.SetActive(false);
    }

    public bool HasWholeMap()
    {
        int mapPartCount = items.Where(t => t.Type.Equals(ItemType.MapPart)).Count();
        bool hasWholeMap = mapPartCount == Globals.mapParts;
        return hasWholeMap;
    }

    private bool HasAnyNeededItem()
    {
        if (Globals.neededItemsCount == items.Count)
            return true;
        return false;
    }
}