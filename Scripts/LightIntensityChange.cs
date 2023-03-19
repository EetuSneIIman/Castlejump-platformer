using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightIntensityChange : MonoBehaviour
{
    public Light2D myLight;
    public float intensityValue = 1f;

    void Start()
    {
        myLight = GetComponent<Light2D>();
    }

    void Update()
    {
        intensityValue = Random.Range(1, 3);
        myLight.intensity = Mathf.PingPong(Time.time, intensityValue);
    }
}
