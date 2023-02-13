using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private GameObject roadblock;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    //has raw essence -- attach to player?
    //private static bool hasRawEssence;
    //has correct essence equipped -- malleable...
    //private bool correctEssence -- for later when we have more than one
    //private DialogueVariables dialogueVariables;

    private void Update() 
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("Interact") && this.CompareTag("interRoadblock")) //&& hasCorrectEssence
            {
                bool hascorrectEssence = ((Ink.Runtime.BoolValue) DialogueManager
                    .GetInstance()
                    .GetVariableState("has_correctEssence")).value;
                if (hascorrectEssence)
                {
                    gameObject.SetActive(false);
                    roadblock.SetActive(false);
                    //note: roadblocks need to have collision, so would this be an invis spot that takes in this script instead
                }
            }

            if (Input.GetButtonDown("Interact") && this.CompareTag("interItem"))
            {
                gameObject.SetActive(false);
                //add to inventory
            }
            
            if (Input.GetButtonDown("Interact") && this.CompareTag("interEssence"))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                gameObject.SetActive(false);
                //hasRawEssence = true;
                //stretch: play an animation (dearil taking it for you)??
                //variable that can be detected by ink?!?
                //i made a new ink file to edit a new global.... ugh
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