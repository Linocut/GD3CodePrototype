using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDash : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;

    [Header("Bool States")]
    public bool isDashing;
    public bool isInvincible;
    
   

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTime;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.E;
    // Start is called before the first frame update
    void Start()
    {
        isDashing = false;
        isInvincible = false; 
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(dashKey))
            Dash();

        if (dashCdTime > 0)
            dashCdTime -= Time.deltaTime;
    }

    private void Dash()
    {
        // disable player movement? 

        if (dashCdTime > 0) return;
        else dashCdTime = dashCd;

        isDashing = true;
        isInvincible = true;
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        rb.AddForce(forceToApply, ForceMode.Impulse);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private void ResetDash()
    {
        isDashing = false;
        isInvincible = false;
    }


}