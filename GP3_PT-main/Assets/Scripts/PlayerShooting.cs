using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerShooting : MonoBehaviour
{
    public Transform orientation;
    private Vector3 mouseWorldPosition;
    public GameObject bullet;
    //shooting
    private GameObject shot;
    public float shotSpeed; 
    AudioSource audioSource;
    public AudioSource gunShot;

    void Start()
    {
        gunShot = GetComponent<AudioSource>();
    }

    
    
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            transform.LookAt(orientation);
            PlayerShoot();
            gunShot.Play();

        }
    }

   

    void PlayerShoot()
    {
        //mouse and keyboard
        if (Input.GetButtonDown("Shoot"))
        {
            shot = Instantiate(bullet,transform.position,transform.rotation) as GameObject;
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpeed);

        }    
    }
}
