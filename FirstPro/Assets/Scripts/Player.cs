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

    public APITest DB;
    //Health Bar Attributes
    private int minHealth = 0;
    public int maxHealth = 20;
    public int currentHealth;
    private int minPower = 0;
    public int maxPower = 3;
    public int currentPower;
    public int damage_taken;
    public int damage_inflicted = 50;

    public HealthBar healthBar;
    public powerBar powerBar;
    private Animator animator;
    [SerializeField] Text gameOver;

    private Rigidbody2D rb2d;

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
            StartCoroutine(deadScreen());
            gameOver.text = "GAME OVER!";
            animator.SetBool("isDead", true);
            
        }
        if (currentPower <= minPower)
        {
            currentPower = minPower;
        }
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
        currentPower -= 3;
        powerBar.SetPowerPoints(currentPower);
    }

    public void RegainPower()
    {
        currentPower += 1;

        powerBar.SetPowerPoints(currentPower);
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
    }



    void OnCollisionEnter2D(Collision2D other)
    {

    if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }
    IEnumerator deadScreen(){
        yield return new WaitForSeconds(8f);

        DB.addScore();
        Score.scoreValue = 0;
        Restart();
        
    }

}
