using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinNoise : MonoBehaviour
{
    public AudioManager am; 
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        am.Play("Urchin");
    }
}
