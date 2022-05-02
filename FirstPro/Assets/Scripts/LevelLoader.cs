using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

// Input Fields
    public string userName;
    public string age;

    int ageInt;
    public string eMail;
    
    public string country;


    public GameObject userField;
    public GameObject ageField;
    public GameObject mailField;
    public GameObject countryField;


    public bool canPlay = false;



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

        if (click)
        {
            CheckInfo();

            if (!canPlay)
            {
                click = false;
            }

            else
            {
                PlayGame();
            }

        }


    }

    void clicked()
    {
        click = true;
    }
     

    public void PlayGame()
    {
      
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
        
     }


    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);


        
    }

    void StoreInfo ()
    {
        userName = userField.GetComponent<Text>().text;

        age = ageField.GetComponent<Text>().text;

        eMail = mailField.GetComponent<Text>().text;

        country = countryField.GetComponent<Text>().text;

        

    }

    public void CheckInfo()
    {

        if (!string.IsNullOrEmpty(userName) && (!string.IsNullOrEmpty(age) && (int.Parse(age) > 1 && (int.Parse(age) < 100)) && !string.IsNullOrEmpty(eMail)  && !string.IsNullOrEmpty(country) ))
        {
            Debug.Log("A jugarle");

            canPlay = true;
        }



    
    }


    
}
