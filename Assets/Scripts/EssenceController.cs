using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceController : MonoBehaviour
{
    [Header("Essence")]
    [SerializeField] private GameObject essence;
    private void Awake()
    {
        essence.SetActive(false);
    }

    private void Update() 
    {          
        if (Input.GetButtonDown("Interact"))
        {
            if (Globals.currentEssence != "" && Globals.essenceActivate)
            {
                essence.SetActive(true);
            }    
        }   
    } 
}
