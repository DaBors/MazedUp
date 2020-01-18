using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : MonoBehaviour
{
    private uint cnt = 0;
    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cnt == 150 && isActive == true)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            isActive = false;
            cnt = 0;
        }
        else if (cnt == 150 && isActive == false)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            isActive = true;
            cnt = 0;
        }

        cnt++;
    }
}
