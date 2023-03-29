using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RBPlayerShooting : MonoBehaviour
{
    //public Transform orientation;
    //private Vector3 mouseWorldPosition;
    public GameObject bullet;
    public float shotSpeed;
    //shooting
    private GameObject shot;
    //private Vector3 Offset;
  

    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            RbPlayerShoot();
        }
            
    }

    void RbPlayerShoot()
    {
       
        shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
        
    }
}
