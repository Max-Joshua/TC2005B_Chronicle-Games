using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/* 
Chronicle Games
04/18/2022

-> Retrieves the user information and loads the first level of the game
 

*/
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

    int number;

    void Start()
    {
        startButton.onClick.AddListener(clicked);
    }

    void clicked()
    {
        CheckInfo();
        Components();
    }

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));   
    }
    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
    void StoreInfo ()
    {
        PlayerPrefs.SetString("userName", userName);

        PlayerPrefs.SetInt("age", number);

        PlayerPrefs.SetString("eMail", eMail);

        PlayerPrefs.SetString("country", country);
    }

    void Components()
    {
        userName = userField.GetComponent<Text>().text;

        age = ageField.GetComponent<Text>().text;

        eMail = mailField.GetComponent<Text>().text;

        country = countryField.GetComponent<Text>().text;
    }
    public void CheckInfo()
    {
        if (!string.IsNullOrEmpty(userName)
            && !string.IsNullOrEmpty(eMail) 
            && !string.IsNullOrEmpty(country) 
            && int.TryParse(age, out number) 
            && !string.IsNullOrEmpty(age))
        {
            Debug.Log("A jugarle");
            StoreInfo();
            PlayGame();
        }
    }
}
