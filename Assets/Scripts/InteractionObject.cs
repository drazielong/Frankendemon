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
            if (Input.GetButtonDown("Interact"))
            {
                visualCue.SetActive(false); 
                gameObject.SetActive(false);
                //add to inventory
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