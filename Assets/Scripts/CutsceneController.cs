using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject videoCanvas;
    [SerializeField] private RenderTexture texture;
    [SerializeField] private CanvasGroup dialogueController;
    [SerializeField] private Animator transition;
    [SerializeField] private  float transitionTime = 1f;
    [SerializeField] private GameObject blackoutObj;
    
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private bool isDialogueTrigger;
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
        //cuz when the cutscene starts it goes to the next line, and if we set it to false after that line it wont work
        if (playerInRange && isDialogueTrigger && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            DialogueManager.GetInstance().ContinueStory();
        }
        
        //playerInRange activates cutscene if player hits a trigger
        //Globals.cutscene check is to activate a cutscene in the middle of dialogue
        if ((playerInRange && !isDialogueTrigger || Globals.cutscene == true) && !cutsceneIsPlaying)
        {
            videoPlayer.targetTexture = texture; //WE CAN REUSE THE CANVAS AND TEXTURE YIPPEEEEEEE
            StartCoroutine(PlayCutscene());
        }
        
        if (endReached && !endingCutscene)
        {
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