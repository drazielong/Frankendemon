//https://www.youtube.com/watch?v=gGUtoy4Knnw interactable objects
//https://www.youtube.com/watch?v=VwE-Oo8Sn9A adding item to inventory

//alright so apparently if u try to interact when ur not near an object it kinda breaks
//deprecated for now...

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
           currentObj.SendMessage("DoInteraction");
        }
        /*
        else if (Input.GetButtonDown("Interact") && currentObj.CompareTag("interChar")) 
        {
            currentObj.SendMessage("Update");
        }
        */
        //note: if i wanted all interaction to be based around the player instead of attaching to objects
        //i would need to have the visualcue be called from here instead of at the object
        //actually i think thats it and it should be easy.
        //on enter and exit add || other.CompareTag("interChar")
    }

    //set current obj to the one you are touching if its an interactable object (tag)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            currentObj = other.gameObject; 
        }
    }
    //when ur not touching, reset to null
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if(other.gameObject == currentObj)
            {
                currentObj = null; 
            }
        }
    }
}
