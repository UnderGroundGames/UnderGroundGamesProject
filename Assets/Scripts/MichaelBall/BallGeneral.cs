using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneral : MonoBehaviour
{
    private Vector3 ballStartPos;
    private GameObject P1Heart1;
    private GameObject P1Heart2;
    private GameObject P1Heart3;
    private GameObject P2Heart1;
    private GameObject P2Heart2;
    private GameObject P2Heart3;
    void Start(){
        ballStartPos = transform.position;
        
        Reset();
        EventScript.current.onResetGame += Reset;
        P1Heart1 = GameObject.Find("P1 Heart 1");
        P1Heart2 = GameObject.Find("P1 Heart 2");
        P1Heart3 = GameObject.Find("P1 Heart 3");
        P2Heart1 = GameObject.Find("P2 Heart 1");
        P2Heart2 = GameObject.Find("P2 Heart 2");
        P2Heart3 = GameObject.Find("P2 Heart 3");
    }
    void Update() {
	if (HitGround.P1Lives == 3) {
		P1Heart1.SetActive(true);
                P1Heart2.SetActive(true);
                P1Heart3.SetActive(true);
        }
        else if (HitGround.P1Lives == 2) {
		P1Heart1.SetActive(true);
                P1Heart2.SetActive(true);
                P1Heart3.SetActive(false);
        }
        else if (HitGround.P1Lives == 1) {
		P1Heart1.SetActive(true);
                P1Heart2.SetActive(false);
                P1Heart3.SetActive(false);
        }
        else if (HitGround.P1Lives == 0) {
		P1Heart1.SetActive(false);
                P1Heart2.SetActive(false);
                P1Heart3.SetActive(false);
        }
        if (HitGround.P2Lives == 3) {
		P2Heart1.SetActive(true);
                P2Heart2.SetActive(true);
                P2Heart3.SetActive(true);
        }
        else if (HitGround.P2Lives == 2) {
		P2Heart1.SetActive(true);
                P2Heart2.SetActive(true);
                P2Heart3.SetActive(false);
        }
        else if (HitGround.P2Lives == 1) {
		P2Heart1.SetActive(true);
                P2Heart2.SetActive(false);
                P2Heart3.SetActive(false);
        }
        else if (HitGround.P2Lives == 0) {
		P2Heart1.SetActive(false);
                P2Heart2.SetActive(false);
                P2Heart3.SetActive(false);
        }
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
