using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;

    public GameObject player2;
    // Update is called once per frame
    void Update()
    {
        if(player1.GetComponentInChildren<PlinthScript>().GetWinCondition() && player2.GetComponentInChildren<PlinthScript>().GetWinCondition())
        {
            Debug.Log("Winning");
        }
    }
}
