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
    //public GameObject audioManagerObject; 

    private GameObject shot;
 


    void Start()
    {

  

       InvokeRepeating("Shoot",spawnDelay, spawnRate);   
    }


    void Shoot(){
        if(gameObject.active){
            //audioManagerObject.GetComponent<AudioManager>().Play("EnemyBullet");
            shot = Instantiate(bullet,transform.position,transform.rotation);
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpeed);
        }
        
    }


}
