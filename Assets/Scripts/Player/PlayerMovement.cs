using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script controls moving left, right, jumping, and wall diving
*/

/*
Need to add:
Diffrent controls for difrent players
Moving
Jumping
Wall diving
*/

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //RETURN
        //playerRB.velocity.x = Input.GetAxisRaw<"Horizontal">()
    }
}
