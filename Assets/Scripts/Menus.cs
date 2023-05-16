//https://www.youtube.com/watch?v=NRUk7YzXyhE
//https://www.youtube.com/watch?v=YOaYQrN1oYQ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class Menus: MonoBehaviour
{   
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        PlayerMovement.isPaused = false;
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        PlayerMovement.isPaused = false;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int val)
    {
        if (val == 0)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
            Debug.Log("0 " + Screen.width + Screen.height);
        }
        if (val == 1)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen);
        }
        if (val == 2)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen);
        }
    }
}
