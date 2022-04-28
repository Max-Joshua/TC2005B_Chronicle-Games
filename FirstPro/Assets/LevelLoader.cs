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


     public bool click = false;


    void Start()
     {
        startButton.onClick.AddListener(clicked);


    }

    void Update()
    {
        // if (click)
        // {
        //  LoadNextLevel();
        // }

        if (click)
        {
            LoadNextLevel();
        }


    }

    void clicked()
    {
        click = true;
    }
     

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
