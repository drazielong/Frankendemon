using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private bool playerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        if (playerInRange)
        {
            visualCue.SetActive(true); 
            if (Input.GetButtonDown("Interact")) //&& is interobj
            {
                visualCue.SetActive(false); 
                gameObject.SetActive(false);
                //add to inventory
            }
            /*
            if (Input.GetButtonDown("Interact")) //&& is interessence
            {
                visualCue.SetActive(false); 
                gameObject.SetActive(false);
                //add to essence inventory
                //stretch: play an animation (dearil taking it for you)
                //stretch stretch: essence is unusable until you take it to Mortis who generates new limbs for you ...
            }
            */
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