using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Variables")]
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [Header("Charge Variables")]
    public int maxCharge = 10;
    [SerializeField] private int currentCharge;


    [Header("References")]
    public HealthBar healthBar;
    public ChargeBar chargeBar;
    public BubbleDash bubbleDash; 

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentCharge = maxCharge;
        chargeBar.SetMaxCharge(maxCharge);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            UseCharge(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!bubbleDash.isInvincible)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
        
    }

    void UseCharge(int used)
    {
        currentCharge -= used;

        chargeBar.SetCharge(currentCharge);
    }
}
