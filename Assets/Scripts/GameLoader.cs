using KrakJam2022;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.Instance.HasMission)
            GameStateMachine.Instance.Switch(GameStateType.Game);
    }
}