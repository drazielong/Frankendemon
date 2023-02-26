using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] private GameObject item;
    private void Update()
    {
        //prob fine if i dont run the check bc its running in currentequip
        //essence show or hide (hide is default)
        //note: detecting if you're holding a raw essence shouldn't be a factor
        //instead we're gonna make an array or something listing all of your collected powers
        //here we will run thru it and check to make sure we don't have the power already
        if (item.CompareTag("interEssence"))
        {
            if (Globals.currentEssence == "Ciara" && !Globals.hasRawEssence)
            {
                item.SetActive(true);
            }
            else 
            {
                item.SetActive(false);
            }
        }

        //FOR MULTI ESSENCES:
        //serializefield private string correctEssence
            //manually input which essence its related to
            //use in place of current essence held bc its specific to ciara
        //serializefield private string collectedPower
            //specific to each essence, input the name of the power its related to
            //this name will be in an array of collected powers
        //serializefield private string correctPower
            //manually input which power clears the roadblock in unity per roadblock
            //use in place of ciara since its specific to ciara


        //switch statement to show colors based on name (ex: ciara = orange essence)
        //shown in the variable observer video 
        /*
        switch (rawEssenceName)
        {
            case "":         
                essence.SetActive(false);
                break;
            case "Ciara":
                //set to orange
                essence.SetActive(true);
                break;
            default:
                Debug.LogWarning("not handled by switch statement:" + rawEssenceName);
                break;
        }

        
        if (Input.GetButtonDown("Interact") && this.CompareTag("interItem"))
        {
            gameObject.SetActive(false);
            //add to inventory
        }
        */
    }
}
