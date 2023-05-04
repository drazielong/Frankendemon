using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject canvasUI;
    [SerializeField] private Animator transition;
    [SerializeField] private  float transitionTime = 1f;
    private bool playerInRange;
    public static bool cutsceneIsPlaying;
    private bool endReached;
    private bool endingCutscene = false;
    private void Start()
    {
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = false;
        videoPlayer.frame = 0;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
    }

    private void Update()
    {
        if ((playerInRange || Globals.cutscene == true) && !cutsceneIsPlaying) //after playing, set this to false
        {
            StartCoroutine(PlayCutscene());
        }
        
        if (endReached && !endingCutscene)
        {
            StartCoroutine(EndCutscene());
        }
    }

    private IEnumerator PlayCutscene()
    {
        canvasUI.SetActive(false);
        cutsceneIsPlaying = true;

        transition.Play("Crossfade_Start");
        yield return new WaitForSeconds(transitionTime);

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
        
        transition.Play("Crossfade_End");
        Debug.Log("Destroying video"); //so we dont see it as we fade back out
        Destroy(videoPlayer);
        yield return new WaitForSeconds(transitionTime);
        
        cutsceneIsPlaying = false; //finally we can regain movement
        canvasUI.SetActive(true);

        Debug.Log("Destroying trigger");
        Destroy(gameObject);
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) //end of vid thing
    {
        endReached = true;
        Debug.Log("Done Playing Video " + endReached);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}