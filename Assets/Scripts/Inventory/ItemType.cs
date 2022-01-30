using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum ItemType
{
    MapPart = 1 << 0,
    Key = 1 << 1,
    Shovel = 1 << 2,
}