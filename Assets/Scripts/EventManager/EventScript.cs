using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    public static EventScript current;

    private void Awake(){
        current = this;
    }
    
    public event Action onResetGame;

    public void resetGame(){
        if(onResetGame != null){
            onResetGame();
        }
    }
}
