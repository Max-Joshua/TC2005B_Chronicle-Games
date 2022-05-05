using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public APITest DB;

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


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;

    public float totalNotes;
    private float normalHits, goodHits, perfectHits, missedHits;
    public GameObject resutlScreen;
    public Text percentHitText, normalText, goodText, perfectText, missedText, rankText, finalScoreText;

    public Button NL;
    public bool click = false;

    
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;

        NL.onClick.AddListener(clicked);

    }

    void clicked()
    {
        click = true;
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

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit/ totalNotes) * 100;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if (percentHit > 40)
                {
                    rankVal = "D";

                    if(percentHit > 55)
                    {
                        rankVal = "C";

                        if(percentHit > 70)
                        {
                            rankVal = "B";

                            if(percentHit > 85)
                            {
                                rankVal = "A";

                                if(percentHit > 95)
                                {
                                    rankVal = "S";

                                    if(percentHit == 100)
                                    {
                                        rankVal = "GOD";
                                    }
                                }
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = Score.scoreValue.ToString();

                

                

            }
            
        }

        if (click)
        {
           NextLevel();
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

        scoreText.text = "Score: " + Score.scoreValue;
    }

    public void NoteMissed()
    {

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
    }

    public void NormalHit()
    {
        Score.scoreValue += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        Score.scoreValue += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        Score.scoreValue += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }


    public void NextLevel()
    {
        DB.addScore();
        DB.addStatistics();
        DB.addUsers();
        DB.addScoreEnemies();
        DB.addScoreNotes();

        Score.scoreValue = 0;

        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    
    }




}
