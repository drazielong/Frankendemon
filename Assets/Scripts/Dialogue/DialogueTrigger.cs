using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true); 
            if (this.CompareTag("interRoadblock") && Input.GetButtonDown("Interact"))
            {
                if (Globals.currentPower == "Ciara")
                {
                    visualCue.SetActive(false);
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                    gameObject.SetActive(false);
                }
                else
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                }
            }
            
            if (Input.GetButtonDown("Interact") && this.CompareTag("interEssence"))
            {
                visualCue.SetActive(false);
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                gameObject.SetActive(false);
            }

            if (Input.GetButtonDown("Interact"))
            {
                visualCue.SetActive(false); 
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
