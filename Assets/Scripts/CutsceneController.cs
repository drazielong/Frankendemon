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
    public GameObject blackOutSquare;
    private bool playerInRange;
    private void Start()
    {
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
    }

    private void Update()
    {
        //not sure if we need to check for dialogue playing unless i add the feature where u can talk to dearil
        if (playerInRange || Globals.cutscene == true) //after playing, set this to false
        {
            StartCoroutine(BlackOut()); 
            //fade to black (pause) -> load video -> hold on first frame? -> fade out to video -> play -> on end, fade to black -> wait for a sec -> fade back to gameplay (unpause)
        }
    }

    //pause dialogue? or would it just pause naturally since player input is paused
    private void PlayCutscene()
    {
        //play cutscene
        videoPlayer.Prepare();
        videoPlayer.Play();

        videoPlayer.loopPointReached += EndReached; //detect end of vid
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) //end of vid thing
    {
        Debug.Log("Done Playing Video");
        Destroy(videoPlayer);

        //fade back out to gameplay before killing trigger
        //StartCoroutine(BlackOut(false));
        //Time.timeScale = 1f;
        
        Destroy(gameObject);
    }

    public IEnumerator BlackOut(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        //change the entire color of the square at once since we can't just manipulate the alpha by itself
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
            
        }
        else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        //yield return new WaitForSeconds(5.0f);
        yield return new WaitForEndOfFrame();
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