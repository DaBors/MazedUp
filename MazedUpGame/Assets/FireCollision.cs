using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{
    public float loseTime = 0.5f;
    private bool loseCondition = false;

    private float stayTime = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        stayTime += Time.deltaTime;

        if (stayTime > loseTime)
        {
            loseCondition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stayTime = 0;
        loseCondition = false;
    }

    public bool GetLoseCondition()
    {
        return loseCondition;
    }
}
