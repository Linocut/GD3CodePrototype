using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShield : MonoBehaviour
{
    public GameObject shield;
    public float shieldTime;
    public int shieldCharge; 
    public AudioManager am; 

    private PlayerHealth playerHealth; 
    private bool chargeCheck;

    void OnEnable(){
        //get component for the player health

        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BubbleShield"))
        {
            //check charge amount 
            chargeCheck = playerHealth.ChargeCheck();

            if(chargeCheck){
                playerHealth.UseCharge(shieldCharge);

                am.Play("ShieldActivate");
                shield.gameObject.SetActive(true);
                Invoke("DownShield", shieldTime);

            }
            //decrease charge amount

           
        }
    }
    void DownShield()
    {
        shield.gameObject.SetActive(false);
    }
}
