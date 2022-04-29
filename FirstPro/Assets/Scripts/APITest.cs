using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class DBScore{

    public int damage_inflicted;
    public int total_score;
    public int lost_life;
    public int damage_taken;
}

// Allow the class to be extracted from Unity
[System.Serializable]
public class ScoreList{
    public List<DBScore> lists;
}
public class APITest : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] string url;
    [SerializeField] string getUsersEP;

    // This is where the information from the api will be extracted
    public ScoreList allScores;

    // Update is called once per frame

    public void addScore(){
        StartCoroutine("AddScore");
    }

    IEnumerator GetScores()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            //Debug.Log("Response: " + www.downloadHandler.text);
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            string jsonString = "{\"score\":" + www.downloadHandler.text + "}";
            allScores = JsonUtility.FromJson<ScoreList>(jsonString);
            DisplayScores();
        } else {
            Debug.Log("Error: " + www.error);
        }
    }   
        IEnumerator AddScore()
    {
        /*
        // This should work with an API that does not expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        DBScore testScore = new DBScore();
        testScore.total_score = Score.scoreValue;
        testScore.lost_life = player.currentHealth;
        testScore.damage_inflicted = player.damage_inflicted;
        testScore.damage_taken = player.damage_taken;
        

        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testScore);
        //Debug.Log("BODY: " + jsonData);
        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        UnityWebRequest www = UnityWebRequest.Put(url + getUsersEP, jsonData);
        //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
        // Set the method later, and indicate the encoding is JSON
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            Debug.Log("Response: " + www.downloadHandler.text);
        } else {
            Debug.Log("Error: " + www.error);
        }
    }

    void DisplayScores()
    {
        /*TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadNames(allScores);*/
    }
}
