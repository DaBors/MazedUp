using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinthScript : MonoBehaviour
{
    public float winTime = 0.5f;

    private bool winCondition = false;

    private float stayTime = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        stayTime += Time.deltaTime;

        if (stayTime > winTime)
        {
            winCondition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stayTime = 0;

        winCondition = false;
    }

    public bool GetWinCondition()
    {
        return winCondition;
    }
}
