using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemController : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Correct Power")]
    [SerializeField] private string correctPower;
    /*
    [Header("Next Scene Index")]
    [SerializeField] private int nextSceneIndex;
    */
    [Header("Player Position TP")]
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    //public GameObject Player;
    private bool playerInRange;
    private void Awake()
    {
        visualCue.SetActive(false);
    }
    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);

            if (Input.GetButtonDown("Interact"))
            {
                visualCue.SetActive(false); 
                
                if(this.CompareTag("interItem"))
                {
                    LevelLoader.GetInstance().LoadLevelArea(x, y, z);
                    //load both scenes at the same time to use this :/
                    //the vars will be fine if you switch levels but like... your power will reset for one
                    //second i think npcs will reset positions and roadblocks ?
                    //SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByBuildIndex(nextAreaIndex));
                    return;
                }

                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                
                //we keep the ink variable for ink purposes, but for this we made another variable
                //that holds the same info for unity purposes :)
                if(this.CompareTag("interRoadblock") && Globals.currentPower == correctPower) 
                {
                    gameObject.SetActive(false);
                }
            }
        }
        else 
        {
            visualCue.SetActive(false);
        } 
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
