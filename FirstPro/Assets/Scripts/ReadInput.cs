using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{

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


    void StoreInfo ()
    {
        userName = userField.GetComponent<Text>().text;

        age = ageField.GetComponent<Text>().text;

        eMail = mailField.GetComponent<Text>().text;

        country = countryField.GetComponent<Text>().text;

        ageInt = int.Parse(age);

    }

    void CheckInfo()
    {
        StoreInfo();

        if((!string.IsNullOrEmpty(userName) && userName.Length < 45) && (!string.IsNullOrEmpty(age) && (int.Parse(age) > 1 && (int.Parse(age) < 100)) && (!string.IsNullOrEmpty(eMail) && eMail.Length < 45) && (!string.IsNullOrEmpty(country) && country.Length < 45)))
        {
            Debug.Log("Ahuevo papi");

            canPlay = true;
        }

    }



}
