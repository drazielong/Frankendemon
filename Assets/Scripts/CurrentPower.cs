using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrentPower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIText;
    void Update()
    {
        string currentPower = ((Ink.Runtime.StringValue) DialogueManager
            .GetInstance()
            .GetVariableState("essence_name")).value;

        bool hascorrectEssence = ((Ink.Runtime.BoolValue) DialogueManager
                    .GetInstance()
                    .GetVariableState("has_correctEssence")).value;

        if (hascorrectEssence)
        {
            UIText.text = "Current Power: Ciara";
        }
        else
        {
            UIText.text = "Current Power: None";
        }
    }
}
