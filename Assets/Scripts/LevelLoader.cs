using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //[SerializeField] public int sceneIndex; //manually input level index or name (for now its index)
    public Animator transition;
    public float transitionTime = 1f;
    private static LevelLoader instance; //stole instance from dialoguemanager so i dont have to get component

    void Start ()
    {
        instance = this;
    }
    public static LevelLoader GetInstance()
    {
        return instance;
    }
    public void LoadNextLevel() //honestly this may only be useful when we start the game since we want to be able to access all levels whenever
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //erm idk we gotta make this work
    public void LoadLevelArea(int sceneIndex) //like buildings
    {
        StartCoroutine(LoadLevel(sceneIndex)); 
    }

    //we can consider other areas of a domain that change the screen to be "levels" but buildings would be temporary areas <-map out
    //still name them in order tho? just bc we r using index

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
