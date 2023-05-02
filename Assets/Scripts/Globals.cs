//could be switched to level loader like in FM for multi levels
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public static bool hasRawEssence;
    public static bool essenceActivate;
    public static string currentEssence;
    public static string currentPower; //prob a unity variable tbh but is also used in dialogue so.?? //use an int for ur current equip == position in array lol :)
    public static string correctPower;
    public static float typingSpeed;
    public static bool cutscene;
    public static List<string> powerList = new List<string>(); //list of powers you've collected. entry 0 will be your default look 

    static public void VarCheck()
    {
        hasRawEssence = ((Ink.Runtime.BoolValue) DialogueManager
            .GetInstance()
            .GetVariableState("has_rawEssence")).value;
        
        essenceActivate = ((Ink.Runtime.BoolValue) DialogueManager
            .GetInstance()
            .GetVariableState("essence_activate")).value;

        currentEssence = ((Ink.Runtime.StringValue) DialogueManager
            .GetInstance()
            .GetVariableState("essence_name")).value;

        currentPower = ((Ink.Runtime.StringValue) DialogueManager
            .GetInstance()
            .GetVariableState("power_name")).value;

        typingSpeed = ((Ink.Runtime.FloatValue) DialogueManager
            .GetInstance()
            .GetVariableState("typing_speed")).value;
        
        cutscene = ((Ink.Runtime.BoolValue) DialogueManager
            .GetInstance()
            .GetVariableState("cutscene")).value;
    }
}
