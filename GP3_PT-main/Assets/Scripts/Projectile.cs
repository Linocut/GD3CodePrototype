using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int bulletDamage;

    void Start()
    {
        bulletDamage = 25;
        EnemyHealth enemyHealth = this.transform.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisonEnter(Collision collision)
        {
            if (collision.transform.tag == "Enemy")
            {
            Destroy(collision.gameObject);
            Debug.Log("collision detected");
            }
        }
}
            

