using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int bulletDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
        EnemyHealth enemyHealth = other.transform.GetComponent<EnemyHealth>();
        //Destroy(collision.gameObject);
        enemyHealth.TakeDamage(bulletDamage);
        }
    }
}
            

