using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



<<<<<<< Updated upstream
    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
=======
 
>>>>>>> Stashed changes

    public void QuitGame()
    {

        Debug.Log("Quit");
        Application.Quit();
    }



}
