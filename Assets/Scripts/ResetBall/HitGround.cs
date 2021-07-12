using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour
{
    public GameObject Ball;
    public int Player;
    public static int P1Lives = 3;
    public static int P2Lives = 3; 
    public enum groundSide{
        Left,
        Right
    };
    public groundSide resetSide;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject == Ball){
            EventScript.current.resetGame();
	    if (Player == 1) {
                P1Lives -= 1; 
            }
            if (Player == 2) {
                P2Lives -= 1; 
            }
        }
    }
}
