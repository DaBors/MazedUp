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

        List<FireCollision> FireCollisions1 = new List<FireCollision>(player1.GetComponentsInChildren<FireCollision>());
        List<FireCollision> FireCollisions2 = new List<FireCollision>(player2.GetComponentsInChildren<FireCollision>());

        foreach (FireCollision fc in FireCollisions1)
        {
            if(fc.GetLoseCondition() == true)
            {
                Debug.Log("Losing!");
            }
        }

        foreach (FireCollision fc in FireCollisions2)
        {
            if (fc.GetLoseCondition() == true)
            {
                Debug.Log("Losing!");
            }
        }
    }
}
