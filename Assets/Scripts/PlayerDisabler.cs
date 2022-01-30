using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDisabler
{
    [SerializeField]
    private GameObject objectToDisable;

    public void SetActivity(bool setActive)
    {
        objectToDisable.SetActive(setActive);
    }
}