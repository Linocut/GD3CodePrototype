using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerCurrencyUI playerCurrency; 
    private PlayerHealth playerHealth;
    private Grapple grapple;
    private BubbleDash bubbleDash;
    private BubbleShield bubbleShield;
    private RBPlayerShooting playerShooting;
    private PlayerShooting2 playerShooting2; 
    private GameObject[] playerObjects;
    private GameObject playerCurrencyUIObject;


    [Header("Button Game Object Refs")]
    public GameObject coralButton1;
    public GameObject coralButton2;
    public GameObject coralButton3;

    public GameObject grappleButton1;
    public GameObject grappleButton2;
    public GameObject grappleButton3;

    public GameObject dashButton1;
    public GameObject dashButton2;
    public GameObject dashButton3;

    public GameObject shieldButton1;
    public GameObject shieldButton2;
    public GameObject shieldButton3;

    public GameObject weaponButton; 


    [Header("CoralUp = cost, CoralUpCharge = amount added")]
    public int coralUp1;
    public int coralUp1Charge; 
    public int coralUp2;
    public int coralUp2Charge; 
    public int coralUp3;
    public int coralUp3Charge;




    [Header("DashUp = cost, DashUpCharge = Time added")]
    public int dashUp1;
    public float dashUp1Force;
    public int dashUp2;
    public float dashUp2Force;
    public int dashUp3;
    public float dashUp3Force;

    /*
    private bool grapple1Open;
    private bool grapple2Open;
    private bool grapple3Open;
    */


    [Header("GrappleUp = cost, GrappleUpStun = Time added")]
    public int grappleUp1;
    public float grappleUp1Stun;
    public int grappleUp2;
    public float grappleUp2Stun;
    public int grappleUp3;
    public float grappleUp3Stun;

    [Header("ShieldUp = cost, ShieldUpStun = Time added")]
    public int shieldUp1;
    public float shieldUp1Time;
    public int shieldUp2;
    public float shieldUp2Time;
    public int shieldUp3;
    public float shieldUp3Time;

    [Header("Weapon Upgrade ")]
    public int weaponUp1;
    private bool weaponSwitch = false;


    private bool firstTime = true; 


    public void OnEnable()
    {
        if (firstTime)
        {
            grappleButton2.GetComponent<Button>().interactable = false;
            grappleButton3.GetComponent<Button>().interactable = false;
            dashButton2.GetComponent<Button>().interactable = false;
            dashButton3.GetComponent<Button>().interactable = false;
            shieldButton2.GetComponent<Button>().interactable = false;
            shieldButton3.GetComponent<Button>().interactable = false;
            coralButton2.GetComponent<Button>().interactable = false;
            coralButton3.GetComponent<Button>().interactable = false;

            firstTime = false; 
        }

        playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            if (playerObject.GetComponent<PlayerHealth>() != null)
            {
                //playerHealthObject = playerObject;
                playerHealth = playerObject.GetComponent<PlayerHealth>();
                grapple = playerObject.GetComponentInChildren<Grapple>();
                bubbleDash = playerObject.GetComponent<BubbleDash>();
                bubbleShield = playerObject.GetComponent<BubbleShield>();
                playerShooting = playerObject.GetComponentInChildren<RBPlayerShooting>();
                playerShooting2 = playerObject.GetComponentInChildren<PlayerShooting2>();

            }
            if (playerObject.GetComponent<PlayerCurrencyUI>() != null)
            {
                playerCurrencyUIObject = playerObject;
                playerCurrency = playerCurrencyUIObject.GetComponent<PlayerCurrencyUI>();

            }
        }
       
    }

    public void CoralUpgrade1()
    {
        if (playerCurrency.CheckCurrency(coralUp1))
        {
            playerCurrency.SubtractCurrency(coralUp1);
            playerHealth.AddMaxCharge(coralUp1Charge);
            ButtonSwitch(coralButton1, coralButton2);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void CoralUpgrade2()
    {
        if (playerCurrency.CheckCurrency(coralUp2))
        {
            playerCurrency.SubtractCurrency(coralUp2);
            playerHealth.AddMaxCharge(coralUp2Charge);
            ButtonSwitch(coralButton2, coralButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void CoralUpgrade3()
    {
        if (playerCurrency.CheckCurrency(coralUp3))
        {
            playerCurrency.SubtractCurrency(coralUp3);
            playerHealth.AddMaxCharge(coralUp3Charge);
            ButtonSwitch(coralButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }





    public void GrappleUpgrade1()
    {
        if (playerCurrency.CheckCurrency(grappleUp1))
        {
            playerCurrency.SubtractCurrency(grappleUp1);
            grapple.IncreaseStun(grappleUp1Stun);
            ButtonSwitch(grappleButton1,grappleButton2);
        }
        else
        {
            //can put code in case you can't afford something
        }   
    }

    public void GrappleUpgrade2()
    {

        if (playerCurrency.CheckCurrency(grappleUp2))
        {
            playerCurrency.SubtractCurrency(grappleUp2);
            grapple.IncreaseStun(grappleUp2Stun);
            ButtonSwitch(grappleButton2, grappleButton3);
            
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void GrappleUpgrade3()
    {
        if (playerCurrency.CheckCurrency(grappleUp3))
        {
            playerCurrency.SubtractCurrency(grappleUp3);
            grapple.IncreaseStun(grappleUp3Stun);

            ButtonSwitch(grappleButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }

    }




    public void DashUpgrade1()
    {
        if (playerCurrency.CheckCurrency(dashUp1))
        {
            playerCurrency.SubtractCurrency(dashUp1);
            bubbleDash.IncreaseDash(dashUp1Force);
            ButtonSwitch(dashButton1, dashButton2);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void DashUpgrade2()
    {

        if (playerCurrency.CheckCurrency(dashUp2))
        {
            playerCurrency.SubtractCurrency(dashUp2);
            bubbleDash.IncreaseDash(dashUp2Force);
            ButtonSwitch(dashButton2, dashButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void DashUpgrade3()
    {
        if (playerCurrency.CheckCurrency(dashUp3))
        {
            playerCurrency.SubtractCurrency(dashUp3);
            bubbleDash.IncreaseDash(dashUp3Force);

            ButtonSwitch(dashButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }

    }



    public void ShieldUpgrade1()
    {
        if (playerCurrency.CheckCurrency(shieldUp1))
        {
            playerCurrency.SubtractCurrency(shieldUp1);
            bubbleShield.IncreaseTime(shieldUp1Time);
            ButtonSwitch(shieldButton1, shieldButton2);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void ShieldUpgrade2()
    {

        if (playerCurrency.CheckCurrency(shieldUp2))
        {
            playerCurrency.SubtractCurrency(shieldUp2);
            bubbleShield.IncreaseTime(shieldUp2Time);
            ButtonSwitch(shieldButton2, shieldButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void ShieldUpgrade3()
    {
        if (playerCurrency.CheckCurrency(shieldUp3))
        {
            playerCurrency.SubtractCurrency(shieldUp3);
            bubbleShield.IncreaseTime(shieldUp3Time);
            ButtonSwitch(shieldButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }

    }

    public void WeaponUpgrade()
    {
        if (playerCurrency.CheckCurrency(weaponUp1))
        {
            playerCurrency.SubtractCurrency(weaponUp1);
            //switch weapon scripts, disable the previous oone and enable the new one
            playerShooting.enabled = false;
            playerShooting2.enabled = true; 
            weaponSwitch = true;
            ButtonSwitch(weaponButton);
        }
    }



    private void ButtonSwitch(GameObject buttton1, GameObject button2)
    {
        buttton1.GetComponent<Button>().interactable = false;
        button2.GetComponent<Button>().interactable = true;
    }
    //method overloading >: ) 
    private void ButtonSwitch(GameObject buttton1)
    {
        buttton1.GetComponent<Button>().interactable = false;
    }
}
