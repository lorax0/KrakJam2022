using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : IGameState
{
    private FogController fogController;

    public GameStateType Type => GameStateType.Game;

    public void Enter()
    {
        Debug.LogError($"Enter {Type} state");
        SceneManager.LoadScene(Globals.scene_Game);
    }

    public void Exit()
    {
        Debug.LogError($"Exit {Type} state");
    }
}