using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    private Rigidbody2D ballRB;
    public float launchSpeed = 500f;
    private bool launchLeft = true;


    public void launch(){
        ballRB = gameObject.GetComponent<Rigidbody2D>();
        if(launchLeft){
            ballRB.AddForce(Vector2.left * launchSpeed, ForceMode2D.Impulse);
            launchLeft = false;
        } else {
            ballRB.AddForce(Vector2.right * launchSpeed, ForceMode2D.Impulse);
            launchLeft = true;
        }
    }
}
