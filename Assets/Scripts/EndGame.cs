using Cinemachine;
using KrakJam2022;
using KrakJam2022.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Transform endPosition;
    [SerializeField]
    private TextMeshProUGUI textHandler;
    [SerializeField]
    private CinemachineVirtualCamera camera;
    [SerializeField]
    private GameObject ui;
    [SerializeField]
    private Button exit;

    public void End()
    {
        Debug.Log("END");
        //player.transform.position = endPosition.position;
        var playerRay = FindObjectOfType<PlayerRay>();
        playerRay.Reset();
        textHandler.gameObject.SetActive(true);
        camera.gameObject.SetActive(true);
        GameManager.Instance.BlockMove();
        player.enabled = true;
        ui.SetActive(true);
        exit.onClick.AddListener(delegate { Application.Quit(); });
    }
}
