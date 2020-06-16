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
        
        void Start()
        {
            lightOn = false;
            light.intensity = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (lightOn)
            {
                light.intensity = lightIntensity;
            } else
            {
                light.intensity = 0f;
            }
    }
}
}


