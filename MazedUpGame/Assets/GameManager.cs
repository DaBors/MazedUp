using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    // Update is called once per frame
    void Update()
    {
        if(player1.GetComponentInChildren<PlinthScript>().GetWinCondition() && player2.GetComponentInChildren<PlinthScript>().GetWinCondition())
        {
            WinGame();
        }

        List<FireCollision> FireCollisions1 = new List<FireCollision>(player1.GetComponentsInChildren<FireCollision>());
        List<FireCollision> FireCollisions2 = new List<FireCollision>(player2.GetComponentsInChildren<FireCollision>());

        foreach (FireCollision fc in FireCollisions1)
        {
            if(fc.GetLoseCondition() == true)
            {
                LoseGame();
            }
        }

        foreach (FireCollision fc in FireCollisions2)
        {
            if (fc.GetLoseCondition() == true)
            {
                LoseGame();
            }
        }
    }
    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("Scene1");
    }
}
