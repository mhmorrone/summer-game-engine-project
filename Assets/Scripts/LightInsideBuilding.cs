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
            //Lights in building start turned off by default so the inside of buildings cannot be seen
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
                lightOn = false;//Prevents lights from turning on at the beginning of the game for the most part due to objects being in the room at the start of the game
            }
            if (lightOn)
            {
                light.intensity = lightIntensity;//Light turns on when lightOn is changed to true
            } else
            {
                light.intensity = 0f;//Otherwise, lights stay off
            }
        }

        public void turnLightOn()
        {
            //turns the light on by changing lightOn to being true
            lightOn = true;
        }
    }
}


