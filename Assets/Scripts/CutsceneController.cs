using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [Header("Cutscene Info")]
    [SerializeField] private VideoPlayer videoPlayer; //target video 
    [SerializeField] private GameObject videoCanvas;  //canvas video plays on
    [SerializeField] private RenderTexture texture;  //render texture of canvas
    [SerializeField] private CanvasGroup dialogueController;  //so we can hide dialogue
    [SerializeField] private Animator transition;  //grabbing transition
    [SerializeField] private  float transitionTime = 1f;  //transition time (idk if im ever gonna change this)
    [SerializeField] private GameObject blackoutObj;  //when entering a scene, enable this so we dont see the game before the cutscene loads
    [SerializeField] private TextAsset inkJSON;  //ink file to play if cutscene is dialogue trigger

    [SerializeField] private GameObject disableNPC; //npc to disable
    [SerializeField] private GameObject enableNPC; //npc to enable

    [Header("Booleans")]
    [SerializeField] private bool isDialogueTrigger; //if trigger activates dialogue pre-cutscene
    [SerializeField] private bool isCutsceneTrigger; //if trigger immediately plays cutscene
    [SerializeField] private bool isTeleportTrigger; //if trigger tps player after cutscene

    [Header("Player Coords")]
    [SerializeField] private float x; 
    [SerializeField] private float y; 
    [SerializeField] private float z; 


    private bool playerInRange;
    public static bool cutsceneIsPlaying;
    private bool endReached;
    private bool endingCutscene = false;
    private void Start()
    {
        videoCanvas.SetActive(false);
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = false;
        videoPlayer.frame = 0;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
    }

    private void Update()
    {
        //note: to play dialogue on entry to an area, then play a cutscene, add a trigger with the dialogue JSON
        //then make globals.cutscene = true in script. add at LEAST 2 lines after the cutscene ends before resetting to false
            //uh this is actually dependent on the type of cutscene we r dealing with
        //cuz when the cutscene starts it goes to the next line, and if we set it to false after that line it wont work
        if (playerInRange && isDialogueTrigger && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            DialogueManager.GetInstance().ContinueStory();
        }
        else if ((playerInRange && isCutsceneTrigger 
        || playerInRange && Globals.cutscene == true) //for this one, the trigger doesn't activate cutscene but while the player is inside, the vid will be set to the correct one then the JSON file activates the cutscene
        && !cutsceneIsPlaying)
        {
            //playerInRange activates cutscene if player hits a trigger
            //Globals.cutscene check is to activate a cutscene in the middle of dialogue
            videoPlayer.targetTexture = texture; //WE CAN REUSE THE CANVAS AND TEXTURE YIPPEEEEEEE
            StartCoroutine(PlayCutscene());
        }
        else if (playerInRange)
        {
            videoPlayer.targetTexture = texture;
        }
        
        if (endReached && !endingCutscene)
        {
            //enter params per cutscene (god damn this file is getting crazy)
            //ima be honest i might need some other way to enable and disable multiple NPCs
            if (IsTeleportTrigger)
            {
                PlayerMovement.TeleportPlayer(x, y, z);
                enableNPC.SetActive(true);
                disableNPC.SetActive(false);
                IsTeleportTrigger = false;
            }
            StartCoroutine(EndCutscene());
        }        
    }    

    private IEnumerator PlayCutscene()
    {
        dialogueController.alpha = 0;
        cutsceneIsPlaying = true;

        transition.Play("Crossfade_Start");
        yield return new WaitForSeconds(transitionTime);

        videoCanvas.SetActive(true);
        videoPlayer.Play();

        transition.Play("Crossfade_End");
        yield return new WaitForSeconds(transitionTime);

        videoPlayer.loopPointReached += EndReached; //detect end of vid
    }

    private IEnumerator EndCutscene()
    {
        endingCutscene = true; //this is so we dont have this ienum constantly rerunning while endReached=true

        transition.Play("Crossfade_Start");
        yield return new WaitForSeconds(transitionTime);

        dialogueController.alpha = 1;
        transition.Play("Crossfade_End");

        Debug.Log("Disabling video"); //so we dont see it as we fade back out
        videoCanvas.SetActive(false);
        yield return new WaitForSeconds(transitionTime);
        
        cutsceneIsPlaying = false; //finally we can regain movement

        //play post cutscene dialogue if dialogue has not already been playing
        if (!DialogueManager.GetInstance().dialogueIsPlaying && !isDialogueTrigger)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            DialogueManager.GetInstance().ContinueStory();
        }

        Debug.Log("Destroying trigger, resets");
        Destroy(this);
        Destroy(blackoutObj);
        playerInRange = false;
        Globals.cutscene = false;
        videoPlayer.targetTexture = null;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) //end of vid thing
    {
        endReached = true;
        Debug.Log("Done Playing Video");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}