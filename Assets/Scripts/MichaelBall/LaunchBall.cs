using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    private Rigidbody2D ballRB;
    public float launchSpeed = 500f;
    void Start()
    {
        ballRB = gameObject.GetComponent<Rigidbody2D>();
        ballRB.AddForce(Vector2.left * launchSpeed, ForceMode2D.Impulse);
    }
}
