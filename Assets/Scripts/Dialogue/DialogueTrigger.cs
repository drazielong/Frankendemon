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

            if (Input.GetButtonDown("Interact"))
            {
                //prob dont need this 
                //Globals.VarCheck(); //update vars again ^_^
                visualCue.SetActive(false); 
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                
                if(this.CompareTag("interEssence"))
                {
                    DialogueManager.GetInstance().ContinueStory();
                    gameObject.SetActive(false);
                }
                if(this.CompareTag("interRoadblock"))
                {
                    DialogueManager.GetInstance().ContinueStory();
                }
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }

        //TODO: roadblock dialogue is kind of buggy -- idk why the overlay moves away ? its only on this.... 
        if(DialogueManager.GetInstance().dialogueIsPlaying && this.inkJSON.name == "Roadblock") //LETS GOOOOOOO
        {
            if (Globals.currentPower == Globals.correctPower) 
            {
                gameObject.SetActive(false);
            }
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
