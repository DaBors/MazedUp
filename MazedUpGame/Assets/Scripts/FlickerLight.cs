using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public float FlickerSpeed = 1;

    public float MinStrength = 0.1f;
    public float MaxStrength = 1.0f;

    private Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>(); 
    }
    void Update()
    {
        pointLight.intensity = Mathf.Lerp(pointLight.intensity, Random.Range(MinStrength, MaxStrength), Time.deltaTime * FlickerSpeed);
    }
}
