using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    public static pause instance;
    public GameObject pauseMenu;
    private void Awake()
    {
        instance = this;
        Hide();
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void Hide()
    {
        Time.timeScale = 1;
        if (player_movement.instance != null)
        {
            player_movement.instance.isPaused = false;
        }
        gameObject.SetActive(false);
    }

    public void Show()
    {
        Time.timeScale = 0;
        player_movement.instance.isPaused = true;
        ShowPauseMenu();
        gameObject.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void GoMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
