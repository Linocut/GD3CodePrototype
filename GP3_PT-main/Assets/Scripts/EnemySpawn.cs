using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyArray; 


    private int i ; 
   

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            for(i = 0; i < enemyArray.Length; i++)
            {
                enemyArray[i].SetActive(true); 
            }
            
        }
    }  
}
