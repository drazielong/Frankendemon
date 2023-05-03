using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

//fade to black tutorial
//https://turbofuture.com/graphic-design-video/How-to-Fade-to-Black-in-Unity

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Animator transition;
    [SerializeField] private  float transitionTime = 1f;
    private bool playerInRange;
    public static bool cutsceneIsPlaying;
    private bool endReached;
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
        if (endReached)
        {
            StartCoroutine(EndCutscene());
        }
    }

    private IEnumerator PlayCutscene()
    {
        cutsceneIsPlaying = true;

        transition.Play("Crossfade_Start");
        yield return new WaitForSeconds(transitionTime);

        //load if need be?
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;

        transition.Play("Crossfade_End");
        yield return new WaitForSeconds(transitionTime);
    }

    private IEnumerator EndCutscene()
    {
        transition.Play("Crossfade_Start");
        yield return new WaitForSeconds(transitionTime);
        transition.Play("Crossfade_End");
        
        Debug.Log("Destroying video");
        Destroy(videoPlayer);
        Debug.Log("cutscene is playinjg = false, inrange false");
        cutsceneIsPlaying = false;
        playerInRange = false;

        Debug.Log("Destroying trigger");
        Destroy(gameObject);
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) //end of vid thing
    {
        endReached = true;
        Debug.Log("Done Playing Video" + endReached);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}