using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType
{
    MainMenu = 1 << 0,
    LevelManager = 1 << 1,
    Game = 1 << 2,
}