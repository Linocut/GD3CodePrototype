using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerShooting : MonoBehaviour
{
    public Transform player;
    public GameObject playerBullet;
    //shooting
    private GameObject shot;
    public float shotSpeed; 
    public KeyCode shootKey = KeyCode.Mouse1;
    //might take out
    private Vector3 mousePosition;
    private Vector3 vectorHit;
    private Camera mainCamera;
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
            Shoot();

            transform.LookAt(player);
    }

    void Shoot(){
        //mouse and keyboard
        if (Input.GetKeyDown(shootKey))
        {
            shot = Instantiate(playerBullet,transform.position,transform.rotation);
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpeed);
        }
    }
}