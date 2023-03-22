using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform player; 
    public GameObject bullet; 

    public float spawnRate; 
    public float spawnDelay; 
    public float shotSpeed; 

    private GameObject shot;

    void Start()
    {

       InvokeRepeating("Shoot",spawnDelay, spawnRate);   
    }

    void Update()
    {
        transform.LookAt(player);
    }
    void Shoot(){
        if(gameObject.active){
            shot = Instantiate(bullet,transform.position,transform.rotation);
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpeed);
        }
        
    }


}
