using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerShooting : MonoBehaviour
{
    public Transform orientation;
    private Vector3 mouseWorldPosition;
    public GameObject playerBullet;
    //shooting
    private GameObject shot;
    public float shotSpeed; 
    public KeyCode shootKey = KeyCode.Mouse1;
    //placeholder for later
    public KeyCode shootButton = KeyCode.JoystickButton7;
    //might take out
    private Vector3 vectorHit;
   
    void Start()
    {
        
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
            shot = Instantiate(playerBullet,transform.position,transform.rotation);
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpeed);
        }
    }
}
