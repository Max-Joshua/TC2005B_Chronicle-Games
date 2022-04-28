using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossLoader : MonoBehaviour
{
     public Animator transition;

    public float transitionTime;

    public bool toBoss = false;


    void Start()
    {


    }

    void Update()
    {

        if (toBoss)
        {
            LoadNextLevel();
        }


    }

    // void Boss()
    // {
    //     toBoss = true;
    // }


    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Player")
        {
            Debug.Log("Triggered");
            toBoss = true;
        }
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
