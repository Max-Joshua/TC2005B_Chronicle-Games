using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

   public Animator transition;

    public float transitionTime;

    public Button startButton;


    void Start()
    {
        startButton.onClick.AddListener(LoadNextLevel);

    }
    // void Update()
    // {
        
    //     LoadNextLevel();
        
        
    // }
     

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }


    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
