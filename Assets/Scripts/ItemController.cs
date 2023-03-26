using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Correct Power")]
    [SerializeField] private string correctPower;
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

            if (Input.GetButtonDown("Interact"))
            {
                visualCue.SetActive(false); 
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);

                if(this.CompareTag("interEssence"))
                {
                    DialogueManager.GetInstance().ContinueStory();
                    gameObject.SetActive(false);
                }
                
                //we keep the ink variable for ink purposes, but for this we made another variable
                //that holds the same info for unity purposes :)
                if(this.CompareTag("interRoadblock") && Globals.currentPower == correctPower) 
                {
                    gameObject.SetActive(false);
                }
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
