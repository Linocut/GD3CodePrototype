using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject playerBullet;
    public int damage =25;

    void Start()
    {
        currentHealth = maxHealth;
    }



    // Update is called once per frame
    void Update()
    {
    }



    void TakeDamage(int damage)
    {
            currentHealth -= damage;
            if(currentHealth <=0);
            Destroy(gameObject);
    }
}
