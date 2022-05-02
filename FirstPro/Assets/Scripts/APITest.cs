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
public class DBStatistics{

    public float accuracy;
    public float game_time;
    public int deaths;

}
public class DBUsers{

    public string name;
    public string mail;
    public int age;
    public string country;

}
public class DBScoreNotes{
    public int notes;

}
public class DBScoreEnemies{
    public int numOfEnemies;

}

// Allow the class to be extracted from Unity
[System.Serializable]
public class ScoreList{
    public List<DBScore> _scorelists;
}

[System.Serializable]
public class StatisticsList{
    public List<DBStatistics> _statisticsList;

}
[System.Serializable]
public class UsersList{
    public List<DBUsers> _usersList;

}
[System.Serializable]
 public class ScoreNotesList{
     public List<DBScoreNotes> _scoreNotesList;

 }
[System.Serializable]
public class ScoreEnemiesList{
    public List<DBScoreEnemies> _scoreEnemiesList;

}
public class APITest : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] string url;
    [SerializeField] string getScoreEP;
    [SerializeField] string getStatisticsEP;
    [SerializeField] string getUsersEP;
    [SerializeField] string getScoreNotesEP;
    [SerializeField] string getScoreEnemiesEP;


    // This is where the information from the api will be extracted
    public ScoreList allScores;
    public StatisticsList allStatistics;
    public UsersList allUsers;
    public ScoreNotesList allScoreNotes;
    public ScoreEnemiesList allScoreEnemies;

    // Update is called once per frame

    //DBScore functions
    public void addScore(){
        StartCoroutine("AddScore");
    }

    IEnumerator GetScores()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + getScoreEP);
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
        UnityWebRequest www = UnityWebRequest.Put(url + getScoreEP, jsonData);
        //UnityWebRequest www = UnityWebRequest.Post(url + getScoreEP, form);
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
        TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadScores(allScores);
    }

    //DBStatistics functions
    public void addStatistics(){
        StartCoroutine("AddStatistics");
    }
    IEnumerator GetStatistics()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + getStatisticsEP);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            //Debug.Log("Response: " + www.downloadHandler.text);
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            string jsonString = "{\"statistics\":" + www.downloadHandler.text + "}";
            allStatistics = JsonUtility.FromJson<StatisticsList>(jsonString);
            DisplayStatistics();
        } else {
            Debug.Log("Error: " + www.error);
        }
    }   
    IEnumerator AddStatistics()
    {
        /*
        // This should work with an API that does not expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        DBStatistics testStatistic = new DBStatistics();
        testStatistic.accuracy = player.accuracy;
        testStatistic.game_time = player.inGameTimer;
        testStatistic.deaths = player.deaths;


        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testStatistic);
        //Debug.Log("BODY: " + jsonData);
        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        UnityWebRequest www = UnityWebRequest.Put(url + getStatisticsEP, jsonData);
        //UnityWebRequest www = UnityWebRequest.Post(url + getStatisticsEP, form);
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
    void DisplayStatistics()
    {
        /*TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadNames(allStatistics);*/
    }
    public void addUsers(){
        StartCoroutine("AddUsers");
    }
    IEnumerator GetUsers()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            //Debug.Log("Response: " + www.downloadHandler.text);
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            string jsonString = "{\"user_info\":" + www.downloadHandler.text + "}";
            allUsers = JsonUtility.FromJson<UsersList>(jsonString);
            DisplayUsers();
        } else {
            Debug.Log("Error: " + www.error);
        }
    }  
    IEnumerator AddUsers()
    {
        /*
        // This should work with an API that does not expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        DBUsers testUser = new DBUsers();
        testUser.name = PlayerPrefs.GetString("userName");
        testUser.mail = PlayerPrefs.GetString("eMail");
        testUser.age = PlayerPrefs.GetInt("age");
        testUser.country = PlayerPrefs.GetString("country");


        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testUser);
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
    void DisplayUsers()
    {
        /*TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadNames(allStatistics);*/
    }

    public void addScoreEnemies(){
        StartCoroutine("AddScoreEnemies");
    }
    IEnumerator GetScoreEnemies()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + getScoreEnemiesEP);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            //Debug.Log("Response: " + www.downloadHandler.text);
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            string jsonString = "{\"user_info\":" + www.downloadHandler.text + "}";
            allScoreEnemies = JsonUtility.FromJson<ScoreEnemiesList>(jsonString);
            DisplayUsers();
        } else {
            Debug.Log("Error: " + www.error);
        }
    }  
    IEnumerator AddScoreEnemies()
    {
        /*
        // This should work with an API that does not expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        DBScoreEnemies testScoreEnemies = new DBScoreEnemies();
        testScoreEnemies.numOfEnemies = 10;


        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testScoreEnemies);
        //Debug.Log("BODY: " + jsonData);
        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        UnityWebRequest www = UnityWebRequest.Put(url + getScoreEnemiesEP, jsonData);
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
    void DisplayScoreEnemies()
    {
        /*TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadNames(allStatistics);*/
    }

     public void addScoreNotes(){
         StartCoroutine("AddScoreNotes");
     }
    
     IEnumerator GetScoreNotes()
     {
         UnityWebRequest www = UnityWebRequest.Get(url + getScoreNotesEP);
         yield return www.SendWebRequest();

         if (www.result == UnityWebRequest.Result.Success) {
             //Debug.Log("Response: " + www.downloadHandler.text);
             // Compose the response to look like the object we want to extract
             // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
             string jsonString = "{\"score_notes\":" + www.downloadHandler.text + "}";
             allScoreNotes = JsonUtility.FromJson<ScoreNotesList>(jsonString);
             DisplayScoreNotes();
         } else {
             Debug.Log("Error: " + www.error);
         }
     }

     IEnumerator AddScoreNotes()
     {
         /*
         // This should work with an API that does not expect JSON
         WWWForm form = new WWWForm();
         form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
         form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
         Debug.Log(form);
         */

         // Create the object to be sent as json
         DBScoreNotes testScoreNotes = new DBScoreNotes();
         testScoreNotes.notes = 500;


         //Debug.Log("USER: " + testUser);
         string jsonData = JsonUtility.ToJson(testScoreNotes);
         //Debug.Log("BODY: " + jsonData);
         // Send using the Put method:
         // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
         UnityWebRequest www = UnityWebRequest.Put(url + getScoreNotesEP, jsonData);
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

     void DisplayScoreNotes()
     {
         /*TMPro_Test texter = GetComponent<TMPro_Test>();
         texter.LoadNames(allStatistics);*/
     }

}
