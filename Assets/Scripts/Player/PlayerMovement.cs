using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script controls moving left, right, jumping, and wall diving
*/

/*
Need to add:
Diffrent controls for difrent players
*/

public class PlayerMovement : MonoBehaviour
{
    //Left and right
    [Range(0f, 10f)]
    public float maxSpeed = 3;
    public float speedUpTime = 0.5f;
    private float CurrentSpeed = 0f;
    private float currVel = 0f;

    //Jumpng
    [HideInInspector]
    public bool hasJump = true;
    public float jumpVel = 5f;
    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 1.5f;

    //Diving
    [Range(0f, 180f)]
    public float diveAngle = 50;
    public float diveStrength = 100;
    [HideInInspector]
    public bool canDive = false;
    [HideInInspector]
    public WallDiveAllowed.Side diveSide;
    [HideInInspector]
    public bool isDiving = false;

    //General
    private Rigidbody2D playerRB;

    void Awake()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start(){
        maxSpeed *= 50;
    }

    void FixedUpdate()
    {
        if(!isDiving){ //Used to loose control durring dive
            //Moving side to side
            //Soften start and end
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1){
                CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, maxSpeed, ref currVel, speedUpTime);
            } else {
                CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, 0, ref currVel, speedUpTime);
            }

            //Move
            playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * CurrentSpeed * Time.fixedDeltaTime, playerRB.velocity.y);

            //Jumping
            if(Input.GetAxisRaw("Jump") == 1 && hasJump){
                playerRB.velocity += (Vector2.up * (jumpVel * 50)) * Time.fixedDeltaTime;
                hasJump = false; //Note: Reset in ResetJump script of child
            }

            //Make holding jump allow for longer jumps
            if(playerRB.velocity.y < 0){
                playerRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
            } else if(playerRB.velocity.y > 0 && !Input.GetButton("Jump")){
                playerRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
            }
        }
    }

    void Update(){
        //Wall dive
        if(canDive && !hasJump && Input.GetButtonDown("Jump")){
            Dive();
        }
    }

    private void Dive(){
        isDiving = true;
        Debug.Log("Dove");

        playerRB.velocity = Vector2.zero;

        //Does this need time.deltatime if it is a one time event???
        if(diveSide == WallDiveAllowed.Side.Left){ //Jump to right
            playerRB.AddForce(new Vector2(diveStrength * Mathf.Sin((diveAngle * Mathf.PI)/180), diveStrength * (1 - Mathf.Sin((diveAngle * Mathf.PI)/180))), ForceMode2D.Impulse);
        } else { //Jump left
            playerRB.AddForce(new Vector2(-diveStrength * Mathf.Sin((diveAngle * Mathf.PI)/180), diveStrength * (1 - Mathf.Sin((diveAngle * Mathf.PI)/180))), ForceMode2D.Impulse);
        }

        //Used Mathf.Sin((diveAngle * PI)/180) and inverse to ensure the total vector for all numbers [0, 180] add to 1
    }
}
