using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceController : MonoBehaviour
{
    [Header("Essence")]
    [SerializeField] private GameObject essence;
    private void Update()
    {
        string rawEssenceName = ((Ink.Runtime.StringValue) DialogueManager
            .GetInstance()
            .GetVariableState("essence_name")).value;
        //switch statement to show colors based on name (ex: ciara = orange essence)
        //shown in the variable observer video

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
    }
}
