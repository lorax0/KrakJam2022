using Cinemachine;
using KrakJam2022;
using KrakJam2022.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void End()
    {
        Debug.Log("END");
        player.transform.position = endPosition.position;
        textHandler.gameObject.SetActive(true);
        camera.gameObject.SetActive(true);
        GameManager.Instance.BlockMove();
        player.enabled = true;
    }
}
