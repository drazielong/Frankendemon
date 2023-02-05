//https://www.youtube.com/watch?v=gGUtoy4Knnw interactable objects
//https://www.youtube.com/watch?v=VwE-Oo8Sn9A adding item to inventory

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInteract : MonoBehaviour
{
    public GameObject currentObj = null;

    //this will tell players they can press Z to interact. For NPCs with updated dialogue, we want an exclamation point over their heads so this could be used instead
    //i dont think we have to baby the players into deducing what is an interactable object or not. maybe for the items.
    //hmmm since this is attached to the player im suddenly realizing we can't attach specific ink files... fuk gonna ignore this for now

    void Update() 
    {
        if (Input.GetButtonDown("Interact") && currentObj.CompareTag("interObject")) 
        {
           currentObj.SendMessage ("DoInteraction");
        }
        else if (Input.GetButtonDown("Interact") && currentObj.CompareTag("interChar")) 
        {
            currentObj.SendMessage ("TriggerDialogue");
        }
    }

    //set current obj to the one you are touching if its an interactable object (tag)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject") || other.CompareTag("interChar"))
        {
            //here is where i might split the visualcue but i think we can customize it based on object so it should be ok
            currentObj = other.gameObject; 
        }
    }
    //when ur not touching, reset to null
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject") || other.CompareTag("interChar"))
        {
            if(other.gameObject == currentObj)
            {
                currentObj = null; 
            }
        }
    }
}
