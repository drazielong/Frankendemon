using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentEquip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    void Update()
    {
        Globals.EssenceCheck();

        if (this.CompareTag("essenceText"))
        {
            UIText.text = "Holding Essence: " + Globals.hasRawEssence;
        }

        if (Globals.currentPower != "" && !this.CompareTag("essenceText"))
        {
            UIText.text = "Current Power: " + Globals.currentPower;
        }
        
        if (Globals.currentPower == "" && !this.CompareTag("essenceText"))
        {
            UIText.text = "Current Power: None";
        }
    }
}
