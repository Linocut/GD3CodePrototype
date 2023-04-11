using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    public GameObject player; 



    // Start is called before the first frame update
    void OnEnable()
    {
        

        player.GetComponent<MovementRB>().enabled = false;
        player.GetComponentInChildren<Grapple>().enabled = false;
        player.GetComponent<BubbleDash>().enabled = false;
        player.GetComponent<BubbleShield>().enabled = false;


    }

    // Update is called once per frame
    void OnDisable()
    {
        

        player.GetComponent<MovementRB>().enabled = true;
        player.GetComponentInChildren<Grapple>().enabled = true;
        player.GetComponent<BubbleDash>().enabled = true;
        player.GetComponent<BubbleShield>().enabled = true;
    }

}
