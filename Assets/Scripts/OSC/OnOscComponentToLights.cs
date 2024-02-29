using System.Collections.Generic;
using System.Linq;
using System;
using Unity.VisualScripting;
using Util;
using UnityEngine;

namespace OnOsc
{
    class OnOscComponentToLights : OnOscComponentToTarget
    {

        [SerializeField] OscLightIntensity oscLightIntensityComp;
        void Start()
        {
            onOscType = typeof(OscLightIntensity);
            oscComp = oscLightIntensityComp;
            SetTargetsByType<Light>(transform);
            base.Start();
        }

        void Update()
        {

        }
    }
}