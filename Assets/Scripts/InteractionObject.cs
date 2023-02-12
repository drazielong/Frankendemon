using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject roadblock;

    private bool playerInRange;
    //has raw essence -- attach to player?
    public static bool hasRawEssence;
    //has correct essence equipped -- malleable...
    //private bool correctEssence -- for later when we have more than one

    private void Awake()
    {
        visualCue.SetActive(false);
        //hasRawEssence = false;
    }

    private void Update() 
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);

            if (Input.GetButtonDown("Interact") && this.CompareTag("interRoadblock")) //&& hasCorrectEssence
            {
                visualCue.SetActive(false); 
                gameObject.SetActive(false);
                roadblock.SetActive(false);
                //note: roadblocks need to have collision, so would this be an invis spot that takes in this script instead
            }

            if (Input.GetButtonDown("Interact") && this.CompareTag("interItem"))
            {
                visualCue.SetActive(false); 
                gameObject.SetActive(false);
                //add to inventory
            }
            
            if (Input.GetButtonDown("Interact") && this.CompareTag("interEssence"))
            {
                visualCue.SetActive(false); 
                gameObject.SetActive(false);
                //add to essence "inventory"
                hasRawEssence = true;
                //stretch: play an animation (dearil taking it for you)
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