//https://www.youtube.com/watch?v=NRUk7YzXyhE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class Menus: MonoBehaviour
{   
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    //sigh okay so... how about when ur in a menu or something and u click the mouse we just auto reset the thing??? 
    //only work around i can think of is to do a lil trick like this ....
    //update
    //if no button is currently selected
        //select the top option again

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution ()
    {
        //either read the text and extract value from there or
        //use "option x = y resolution" and so forth ?
        //Screen.SetResolution(x, y, isFullscreen);
    }
}
