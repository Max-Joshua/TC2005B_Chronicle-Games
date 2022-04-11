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


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && currentHealth != maxHealth)
        {
            Heal(1);
        }

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

    void Heal(int heal)
    {
        currentHealth += heal;

        healthBar.SetHeatlh(currentHealth);
    }



    void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
