using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Allow the class to be extracted from Unity
// https://stackoverflow.com/questions/40633388/show-members-of-a-class-in-unity3d-inspector
[System.Serializable]


public class DBScore{

    public int totalDamage;

}

// Allow the class to be extracted from Unity
[System.Serializable]

public class ScoreList{
    public List<DBScore> lists;
}

