using KrakJam2022;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveGroupItems : MonoBehaviour, IInteractable
{
    [SerializeField]
    private CameraZoom cameraZoom;
    [SerializeField]
    private Collider coll;
    [SerializeField]
    private List<InteractiveItem> items;

    private void Awake()
    {
        SetActivity(false);
    }

    public void EnterInteraction()
    {
        SetActivity(true);
        cameraZoom.ZoomIn();
    }

    public void ExitInteraction()
    {
        SetActivity(false);
        cameraZoom.ZoomOut();
    }

    private void SetActivity(bool isActive)
    {
        coll.enabled = !isActive;
        foreach (var item in items)
        {
            item.CanInteract = isActive;
            item.Collider.enabled = isActive;
        }
    }
}