using Cysharp.Threading.Tasks;
using KrakJam2022;
using KrakJam2022.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textHandler;
    [SerializeField]
    protected InputActionReference nextDialogoue;
    [SerializeField]
    private List<Dialogue> dialogues;
    [SerializeField]
    private Dialogue repeatDialogue;
    [SerializeField]
    private int repeatFromIndex;
    [SerializeField]
    private Player player;

    private int index = 0;
    private bool isActive = false;
    private bool toldWholeStory = false;

    private void Update()
    {
        if (!isActive)
            return;
        
        if (InputActionManager.WasPressedButtonThisFrame(nextDialogoue))
        {
            ShowNextDialogue();
        }
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        player.enabled = false;
        player.SetAnimation(false);
        textHandler.gameObject.SetActive(true);
        isActive = true;
        if (!toldWholeStory)
        {
            ShowNextDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
        textHandler.text = repeatDialogue.Text;
        index = repeatFromIndex;
    }

    private void ShowNextDialogue()
    {
        if (index < dialogues.Count)
        {
            textHandler.text = dialogues[index].Text;
            index++;
        }
        else
        {
            GameManager.Instance.HasMission = true;
            textHandler.gameObject.SetActive(false);
            toldWholeStory = true;
            player.enabled = true;
        }
    }
}