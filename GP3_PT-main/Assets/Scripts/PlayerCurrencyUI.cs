using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrencyUI : MonoBehaviour
{
    public GameObject CurrencyUI;
    private int totalCurrency;
    public AudioManager am;

    public void addCurrency(int currency)
    {
        am.Play("Pickup");

        totalCurrency = totalCurrency + currency;
    }
    public void subtractCurrency(int currency)
    {
        totalCurrency = totalCurrency - currency;
    }

    public void Update()
    {
        CurrencyUI.GetComponent<Text>().text = totalCurrency.ToString();
    }
    

    //over here we do a UI display with the uhhh uhhhhh uhuh? .. the currency. 

}
