using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private int minHealth = 0;
    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    private Rigidbody2D rb2d;



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    void Update()
    {

        // if (Input.GetKeyDown(KeyCode.Space) && currentHealth != maxHealth)
        // {
        //     Heal(1);
        // }

        if (currentHealth <= minHealth)
        {
            Restart();
        }

    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHeatlh(currentHealth);

    }

    public void Heal(int heal)
    {
        currentHealth += heal;

        healthBar.SetHeatlh(currentHealth);
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


}
