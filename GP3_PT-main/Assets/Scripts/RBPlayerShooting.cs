using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RBPlayerShooting : MonoBehaviour
{
    public GameObject audioManagerObject;
    public GameObject bullet;
    public float shotSpeed;

    private GameObject shot;
    private AudioManager audioManager;


    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            audioManagerObject.GetComponent<AudioManager>().Play("PlayerBullet");
            RbPlayerShoot();
        }
            
    }

    void RbPlayerShoot()
    {
       
        shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
        
    }
}
