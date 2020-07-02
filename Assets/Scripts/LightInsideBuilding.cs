using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering.Universal
{
    public class LightInsideBuilding : MonoBehaviour
    {
        public Light2D light;
        public bool lightOn;
        public float lightIntensity = 1f;

        float timer;
        
        void Start()
        {
            lightOn = false;
            light.intensity = 0f;
            timer = 0.1f;
        }

        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime;
            if(timer > 0f)
            {
                lightOn = false;
            }
            if (lightOn)
            {
                light.intensity = lightIntensity;
            } else
            {
                light.intensity = 0f;
            }
        }

        public void turnLightOn()
        {
            lightOn = true;
        }
    }
}


