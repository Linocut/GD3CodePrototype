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
    //placeholder button for later
    public KeyCode shootButton = KeyCode.JoystickButton7;
    public int bulletDamage;

    void Start()
    {
        GameObject[] Shooter = GameObject.FindGameObjectsWithTag("Enemy");
        bulletDamage = 25;
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

   void OnCollisonEnter(Collision collision)
        {
          ContactPoint contact = collision.contacts[0];

        if (collision.gameObject.tag == "Enemy")
            {
                //currentDamage += 25;

            }    
        }
    }
}