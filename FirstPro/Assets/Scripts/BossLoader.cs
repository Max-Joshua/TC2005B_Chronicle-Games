using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
Chronicle Games
04/30/2022

-> Change the current scene to the specific level's boss fight

*/

public class BossLoader : MonoBehaviour
{
     public Animator transition;

    public float transitionTime;

    public bool toBoss = false;

    [SerializeField] GameObject Fade;


    void Start()
    {
        Fade.SetActive(false);
    }

    void Update()
    {

        if (toBoss)
        {
            Fade.SetActive(true);
            LoadNextLevel_();
            
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");
            toBoss = true;
        }
    }
     

    public void LoadNextLevel_()
    {
        StartCoroutine(LoadLevel_(SceneManager.GetActiveScene().buildIndex + 1));
        
    }
    


    IEnumerator LoadLevel_ (int levelIndex)
    {
        transition.SetTrigger("StartBoss");
        Debug.Log("Transition");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
