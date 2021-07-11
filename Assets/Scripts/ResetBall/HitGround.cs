using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour
{
    public GameObject Ball;
    public enum groundSide{
        Left,
        Right
    };
    public groundSide resetSide;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject == Ball){
            EventScript.current.resetGame();
        }
    }
}
