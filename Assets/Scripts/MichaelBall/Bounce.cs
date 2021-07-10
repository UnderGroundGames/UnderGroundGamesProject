using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D ballRB;
    public float bounceSpeed = 5f;
    [Range(0f, 1f)]
    public float positionBias = .5f;

    void Start(){
        ballRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Bounce");
        if(col.gameObject.tag == "Player"){
            Transform playerTrans = col.gameObject.transform;

            Vector2 newLaunchAngle = gameObject.transform.position - playerTrans.position;
            newLaunchAngle.Normalize();

            Vector2 combinedLaunchAngle = (newLaunchAngle * positionBias) + (ballRB.velocity * Mathf.Abs(1 - positionBias));
            combinedLaunchAngle.Normalize();

            ballRB.velocity = combinedLaunchAngle * bounceSpeed;

            bounceSpeed += .5f; 
        } else {
            //Keep speed constant
            ballRB.velocity.Normalize();
            ballRB.velocity = ballRB.velocity * bounceSpeed;
        }
    }
}
