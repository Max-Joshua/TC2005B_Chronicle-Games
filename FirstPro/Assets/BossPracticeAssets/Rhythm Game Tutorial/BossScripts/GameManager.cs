using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;


    public static GameManager instance;

    public int currentScore;

    public int scorePerNote = 10;

    public int scorePerGoodNote = 15;

    public int scorePerPerfectNote = 20;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;


    public Text scoreText;
    public Text multiText;

    public float totalNotes;
    public float normalHits, goodHits, perfectHits, missedHits;

    public GameObject resutlScreen;

    public Text percentHitText, normalText, goodText, perfectText, missedText, rankText, finalScoreText;

    
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        else
        {
            if(!theMusic.isPlaying && !resutlScreen.activeInHierarchy)
            {
                resutlScreen.SetActive(true);

                normalText.text = normalHits.ToString();
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missedText.text = missedHits.ToString();
            }
            
        }
    }

    public void NoteHit()
    {

        if (currentMultiplier -1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier ++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        // currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }


}
