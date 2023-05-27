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

    public static GameObject blackoutObj;

    private void Awake()
    {
        blackoutObj = GameObject.Find("Blackout");
    }

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

    public void LoadLevelArea(float x, float y, float z) //like buildings
    {
        StartCoroutine(LoadArea(x, y, z)); 
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play anim
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load 
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadArea(float x, float y, float z)
    {
        transition.Play("Crossfade_Start");
        yield return new WaitForSeconds(transitionTime);
        PlayerMovement.GetInstance().TeleportPlayer(x, y, z);
        transition.Play("Crossfade_End");
    }
}
