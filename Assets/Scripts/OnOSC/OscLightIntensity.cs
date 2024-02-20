using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace OnOsc
{
    public class OscLightIntensity : OnOSCBasic
    {
        Light light;
        
        float initialIntensity;
        // float scaleSpeed = 0.1f;

        void Start()
        {
          
            if(obj.GetComponent<Light>() != null)
            {
                light = obj.GetComponent<Light>(); 
                initialIntensity = light.intensity;
            }
        }

        void Update()
        {
            if (light != null)
            {
                base.Update();
                light.intensity = value * multiply;
            }
        }
    }

}