using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerState : IGameState
{
    private FogController fogController;

    public GameStateType Type => GameStateType.LevelManager;

    public void Enter()
    {
        fogController = MonoBehaviour.FindObjectOfType<FogController>();
        if (fogController != null)
        {
            fogController.SetEmision(50);
        }
        Debug.LogError($"Enter {Type} state");
    }

    public void Exit()
    {
        Debug.LogError($"Exit {Type} state");
    }
}