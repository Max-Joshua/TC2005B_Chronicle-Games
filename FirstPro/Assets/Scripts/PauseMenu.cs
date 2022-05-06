using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* 
Chronicle Games
05/01/2022

-> Pause menu controller script
 

*/
public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource RainSound;

    public AudioSource GameMusic;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        RainSound.Play(0);
        GameMusic.Play(0);
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        RainSound.Pause();
        GameMusic.Pause();
    }

    public void LoadMenu ()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("Menu");
        Resume(); 
        
    
        
        
    }

    public void QuitMenu ()
    {
        Debug.Log("Quitting game...");
        
    }


}