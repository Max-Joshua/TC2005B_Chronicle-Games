using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/* 
Chronicle Games
04/05/2022

-> Controlls the player's health and power levels

*/

public class Player : MonoBehaviour
{

    public float inGameTimer;
    public APITest DB;
    public TriggerSpace triggerSpace_scr;
    public Instantiator instantiator_scr;
    public float accuracy;
    //Health Bar Attributes
    private int minHealth = 0;
    public int maxHealth = 20;
    public int currentHealth;
    private int minPower = 0;
    public int maxPower = 3;
    public int currentPower;
    public int damage_taken;
    public int damage_inflicted;

    public int deaths;

    public HealthBar healthBar;
    public powerBar powerBar;
    private Animator animator;
    [SerializeField] Text gameOver;

    private Rigidbody2D rb2d;


     Scene currentScene;

     string sceneName;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 

        currentPower = maxPower;
        powerBar.SetMaxPower(maxPower); 
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && currentHealth != maxHealth)
        // {
        //     Heal(1);
        // }

        if (currentHealth <= minHealth)
        {
            Die(8.0f);
            
        }
        if (currentPower <= minPower)
        {
            currentPower = minPower;
        }
        inGameTimer += Time.deltaTime;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        damage_taken += damage;
        healthBar.SetHeatlh(currentHealth);

    }

    public void Heal(int heal)
    {
        currentHealth += heal;

        healthBar.SetHeatlh(currentHealth);
    }

    public void UsePower(){
        currentPower -= maxPower;
        powerBar.SetPowerPoints(currentPower);
    }

    public void RegainPower()
    {
        currentPower += 1;

        powerBar.SetPowerPoints(currentPower);
    }

     public void InflictDamage(int damage){
         damage_inflicted += damage;
     }

    public void Die(float seconds){
            StartCoroutine(deadScreen(seconds));
            accuracy = (triggerSpace_scr.totalHitBars / instantiator_scr.numOfLines) * 100;
            gameOver.text = "GAME OVER!";
            animator.SetBool("isDead", true);
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }



    void OnCollisionEnter2D(Collision2D other)
    {

    if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }


    IEnumerator deadScreen(float seconds){
        yield return new WaitForSeconds(seconds);

        deaths += 1;

        DB.addScore();
        DB.addStatistics();
        DB.addUsers();
        DB.addScoreEnemies();
        DB.addScoreNotes();

        Restart();
        
    }

}
