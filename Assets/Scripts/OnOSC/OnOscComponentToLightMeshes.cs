using System.Collections.Generic;
using System.Linq;
using System;
using Unity.VisualScripting;
using Util;
using UnityEngine;

namespace OnOsc
{
    class OnOscComponentToLightMeshes : OnOscComponentToTarget
    {

        [SerializeField] OscMatEmission oscMatEmmisionComp;
        [SerializeField] Material[] mats;
        [SerializeField] string suffix = " (Instance)";
        void Start()
        {
            onOscType = typeof(OscMatEmission);
            oscComp = oscMatEmmisionComp;

            SetTargetByMaterial(transform, mats, suffix);
            base.Start();
        }

        void Update()
        {

        }
    }
}