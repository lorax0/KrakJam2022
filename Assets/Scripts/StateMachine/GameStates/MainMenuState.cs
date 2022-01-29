using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : IGameState
{
    private FogController fogController;

    public GameStateType Type => GameStateType.MainMenu;

    public async void Enter()
    {
        string sceneToLoad = "KarolMainMenu";
        SceneManager.LoadScene(sceneToLoad);
        await UniTask.WaitUntil(() => SceneManager.GetActiveScene().name == sceneToLoad);

        fogController = MonoBehaviour.FindObjectOfType<FogController>();
        if (fogController != null)
        {
            fogController.SetEmision(125);
        }
        Debug.LogError($"Enter {Type} state");
        //SceneManager.LoadScene(Globals.scene_MainMenu);
    }

    public void Exit()
    {
        Debug.LogError($"Exit {Type} state");
    }
}