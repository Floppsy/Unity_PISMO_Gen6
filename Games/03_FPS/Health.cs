using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slideHealth;
    public Text healthText;

    public float maxHealth;
    public float currentHealth;

    public float healthRegen;

    private void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth + "/" + maxHealth;
        slideHealth.maxValue = maxHealth;
        slideHealth.value = currentHealth;
    }

    private void Update()
    {
        if(currentHealth < maxHealth && currentHealth > 0)
        {
            currentHealth += healthRegen * Time.deltaTime;
        }

        if(currentHealth <= 0)
        {
            //Umro si, prikaži neki izbornik sa scorom i resetiraj scenu
        }

        //SLUŽI ZA TESTIRANJE - MAKNUTI KASNIJE
        if(Input.GetKeyDown(KeyCode.Q))
        {
            currentHealth -= 10;
        }

        healthText.text = (int)currentHealth + "/" + maxHealth;
        slideHealth.value = currentHealth;
    }
}
