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
    public KeyCode shootKey = KeyCode.Mouse1;
    //placeholder for later
    public KeyCode shootButton = KeyCode.JoystickButton7;
    //might take out/wip
    private Vector3 vectorHit;
    public int damage =25;
    public GameObject EnemyHealth;
    public Vector3 collision;
    public GameObject damageEffect;
   
    void Start()
    {
        //Shooter = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
            transform.LookAt(orientation);
            PlayerShoot();
    }

    void PlayerShoot(){
        //mouse and keyboard
        if (Input.GetKeyDown(shootKey))
        {
            shot = Instantiate(bullet,transform.position,transform.rotation) as GameObject;
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpeed);
        }

   // void OnCollisonEnter(Collision collision)
        {
          //  ContactPoint contact = collision.contacts[0];
          //  Instantiate(damageEffect,contact.point,Quaternion.LookRotation(contact.normal));

         //   if (collision.gameObject.tag == "Enemy")
            {
           //     EnemyTar
            }
        }           // shot = Instantiate(bullet,position,lookRotation);

    //TakeDamage(20);

    }
}
