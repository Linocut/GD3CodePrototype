using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startDamage = 0;
    public int currentDamage;

    void Start(int enemyDamage)
    {
        startDamage = 0;
        currentDamage = enemyDamage; 
    }



    // Update is called once per frame
    void Update()
    {
    }



    void TakeDamage(int bulletDamage)
    {
            currentDamage += bulletDamage;
            if(currentDamage >=100);
            Destroy(gameObject);
    }
}
