using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startDamage = 0;
    public int currentDamage;

    void Start()
    {
        currentDamage = startDamage; 
    }



    // Update is called once per frame
    void Update()
    {

    }
    public void Projectile(){
    Projectile playerBullet =this.transform.GetComponent<Projectile>();
    Projectile bulletDamage =this.transform.GetComponent<Projectile>();
    }
    
    void TakeDamage(int bulletDamage)
    {
     currentDamage += bulletDamage;

     if (currentDamage >= 100)
        Destroy(this.gameObject);
    }
}
