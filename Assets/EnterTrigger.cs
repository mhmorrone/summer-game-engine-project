using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering.Universal
{
    public class EnterTrigger : MonoBehaviour
    {
        public LightInsideBuilding light;
        void OnTriggerEnter ()
        {
            light.turnLightOn();
        }
    }
}


