using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneral : MonoBehaviour
{
    private Vector3 ballStartPos;
    
    void Start(){
        ballStartPos = transform.position;
        
        Reset();
        EventScript.current.onResetGame += Reset;
    }

    private void Reset(){
        transform.position = ballStartPos;
	Bounce.bounceSpeed = 8f;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
        StartCoroutine(launchInSeconds(3));
    }

    private IEnumerator launchInSeconds(int secondsToLaunch){
        float currGravity = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        Debug.Log(currGravity);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

        yield return new WaitForSeconds(secondsToLaunch);
        
        gameObject.GetComponent<Rigidbody2D>().gravityScale = currGravity;

        gameObject.GetComponent<LaunchBall>().launch();
    }
}
