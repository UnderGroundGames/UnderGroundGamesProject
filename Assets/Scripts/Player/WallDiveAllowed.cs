using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDiveAllowed : MonoBehaviour
{
    public enum Side{
        Left,
        Right
    };

    public Side ColliderSide;
    private PlayerMovement PMScript;

    void Start(){
        PMScript = gameObject.GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerStay2D(Collider2D col){
        //Is close enough to the wall to be allowed
        if(!col.CompareTag("Player")){
            PMScript.canDive = true;
            PMScript.diveSide = ColliderSide;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        //Left the wall
        PMScript.canDive = false;
    }
}
