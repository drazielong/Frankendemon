//could be switched to level loader like in FM for multi levels
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public static bool hasRawEssence;
    public static string currentEssence;
    public static string currentPower; //prob a unity variable tbh but is also used in dialogue so.??
    public static string[] powerList; //list of powers you've collected. entry 0 will be your default look 

    static public void EssenceCheck()
    {
        hasRawEssence = ((Ink.Runtime.BoolValue) DialogueManager
            .GetInstance()
            .GetVariableState("has_rawEssence")).value;

        currentEssence = ((Ink.Runtime.StringValue) DialogueManager
            .GetInstance()
            .GetVariableState("essence_name")).value;

        currentPower = ((Ink.Runtime.StringValue) DialogueManager
            .GetInstance()
            .GetVariableState("power_name")).value;
    }
}
