using Cinemachine;
using KrakJam2022.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button optionsButton;
    [SerializeField]
    private Button creditsButton;
    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private Player player;
    [SerializeField]
    private Ghost ghost;
    [SerializeField]
    private CinemachineVirtualCamera levelManagerCamera;

    private void OnEnable()
    {
        startButton.onClick.AddListener(delegate { OnStartButton(); });
        optionsButton.onClick.AddListener(delegate { OnOptionsButton(); });
        creditsButton.onClick.AddListener(delegate { OnCreditsButton(); });
        exitButton.onClick.AddListener(delegate { OnExitButton(); });
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveAllListeners();
        optionsButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

    public void OnStartButton()
    {
        Debug.Log("start");
        GameStateMachine.Instance.Switch(GameStateType.LevelManager);
        gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        ghost.gameObject.SetActive(true);
        levelManagerCamera.gameObject.SetActive(true);
    }

    public void OnOptionsButton()
    {
        Debug.Log("options");

    }

    public void OnCreditsButton()
    {
        Debug.Log("credits");

    }

    public void OnExitButton()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}