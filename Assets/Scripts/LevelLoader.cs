using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public int sceneIndex;
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()//honestly this may only be useful when we start the game since we want to be able to access all levels whenever
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevelArea() //like buildings
    {
        StartCoroutine(LoadLevel(sceneIndex));
    }

    //we can consider other areas of a domain that change the screen to be "levels" but buildings would be temporary areas <-map out

    IEnumerator LoadLevel(int levelIndex)
    {
        //play anim
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load 
        SceneManager.LoadScene(levelIndex);
    }
}
