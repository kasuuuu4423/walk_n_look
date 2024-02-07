using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace OnOsc
{
    public class OscLightIntensity : MonoBehaviour
    {
        [SerializeField] OSCReceive osc;
        [SerializeField] Light light;
        [SerializeField] float multiply;
        float initialIntensity;
        // float scaleSpeed = 0.1f;

        void Start()
        {
            initialIntensity = light.intensity;
        }

        void Update()
        {
            if (osc.address == "/gain")
            {
                float value = osc.value * multiply;
                light.intensity = value;
            }
        }
    }

}