using UnityEngine;

public class GameState : IGameState
{
    private FogController fogController;

    public GameStateType Type => GameStateType.Game;

    public void Enter()
    {
        Debug.LogError($"Enter {Type} state");
    }

    public void Exit()
    {
        Debug.LogError($"Exit {Type} state");
    }
}