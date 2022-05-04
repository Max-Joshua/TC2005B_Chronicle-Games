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

    int number;

    void Start()
    {
        startButton.onClick.AddListener(clicked);
    }

    void clicked()
    {
        CheckInfo();
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
        userName = userField.GetComponent<Text>().text;
        PlayerPrefs.SetString("userName", userName);

        age = ageField.GetComponent<Text>().text;
        PlayerPrefs.SetInt("age", number);

        eMail = mailField.GetComponent<Text>().text;
        PlayerPrefs.SetString("eMail", eMail);

        country = countryField.GetComponent<Text>().text;
        PlayerPrefs.SetString("country", country);
    }
    public void CheckInfo()
    {
        if ((!string.IsNullOrEmpty(userName))
            && (!string.IsNullOrEmpty(eMail))  
            && (!string.IsNullOrEmpty(country) 
            && (int.TryParse(age, out number) 
            && (!string.IsNullOrEmpty(age)))))
        {
            Debug.Log("A jugarle");
            StoreInfo();
            PlayGame();
        }
    }
}
