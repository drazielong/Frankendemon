using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentEquip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    private string[] powers;
    private int index = 0;

    void Start ()
    {
        Globals.VarCheck(); //initialize global variables idk why i called it this
        AddPower(); //initialize powerlist w initial starting power (noxie)

        if (this.CompareTag("essenceText"))
        {
            UIText.text = "Holding Essence: " + Globals.hasRawEssence;
        }
        else if (!this.CompareTag("essenceText"))
        {
            UIText.text = "Current Power: " + Globals.currentPower;
        }

    }

    public void Update()
    {
        if (this.CompareTag("essenceText"))
        {
            UIText.text = "Holding Essence: " + Globals.hasRawEssence;
        }

        //when you press C not in dialogue, switch to the next item in powers list
        if (Input.GetButtonDown("Menu") && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            AddPower();
            powers = Globals.powerList.ToArray(); //update array with list info
            SwapPower();
            
            if (!this.CompareTag("essenceText"))
            {
                UIText.text = "Current Power: " + Globals.currentPower;
            }
        }
    }

    //swap power in unity
    public void SwapPower()
    {
        index++;
        if (index < powers.Length)
        {
            Globals.currentPower = powers[index];
        }
        else if (index >= powers.Length)
        {
            index = 0;
            Globals.currentPower = powers[0]; 
        }
    }

    public void AddPower() //if currentpower is not in powerlist, add it
    {   
        if (!Globals.powerList.Contains(Globals.currentPower))
        {
            Globals.powerList.Add(Globals.currentPower);
        }
    }
}
