using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetJump : MonoBehaviour
{
    private PlayerMovement PMScript;
    void Start()
    {
        PMScript = gameObject.GetComponentInParent<PlayerMovement>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col){
        //Add requirement for collider
        //Reset if touching ground
        PMScript.hasJump = true;
        PMScript.isDiving = false;
    }
}
