using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : IGameState
{
    public GameStateType Type => GameStateType.MainMenu;

    public void Enter()
    {
        Debug.LogError($"Enter {Type} state");
        //SceneManager.LoadScene(Globals.scene_MainMenu);
        SceneManager.LoadScene("TEST");
    }

    public void Exit()
    {
        Debug.LogError($"Exit {Type} state");
    }
}