using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;
    
    [Header("Player Coords for TP")]
    [SerializeField] private float x; 
    [SerializeField] private float y; 
    [SerializeField] private float z; 
    [SerializeField] private GameObject disableOBJ; //npc OR OBJ to disable
    [SerializeField] private GameObject enableOBJ;

    public static bool tpIsPlaying;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        //if tp in middle of convo
        //note: if i try to make it so that dialogue cant be moved forward while tping, and u tp to another char w a tp, it will
        //automatically trigger the next one once u regain input for dialogue since variables are read after the line (tp doesn't reset)
        //but i cant place tp any higher in the script bc it will be read as true and then false immediately
        if (playerInRange && Globals.tp && Input.GetButtonDown("Interact")) //&& !tpIsPlaying
        {
            StartCoroutine(TP()); 
        }

        //enter dialogue mode
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !PlayerMovement.isPaused)
        {

            visualCue.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                visualCue.SetActive(false); 
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }

    IEnumerator TP() //note maybe reuse the cutscene trigger for tp so we can hide dialogue box
    {
        //tpIsPlaying = true;
        LevelLoader.GetInstance().LoadLevelArea(x, y, z);
        yield return new WaitForSeconds(1);
        
        if (enableOBJ != null)
        {
            enableOBJ.SetActive(true);
        }
        if (disableOBJ != null)
        {
            disableOBJ.SetActive(false);
        }
        //tpIsPlaying = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
