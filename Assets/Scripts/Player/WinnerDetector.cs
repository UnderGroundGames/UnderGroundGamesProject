using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerDetector : MonoBehaviour
{
    public TextMeshProUGUI TMP;
    // Start is called before the first frame update
    void Start()
    {
        if (HitGround.P1Lives == 0)
        {
            TMP.text = "Player 2 Wins";
            HitGround.P1Lives = 3;
            HitGround.P2Lives = 3;
        }else if (HitGround.P2Lives == 0)
        {
            TMP.text="Player 1 Wins";
            HitGround.P1Lives = 3;
            HitGround.P2Lives = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
