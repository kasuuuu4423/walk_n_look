using System.Collections.Generic;
using System.Linq;
using System;
using Unity.VisualScripting;
using Util;
using UnityEngine;

namespace OnOsc
{
    class OnOscScaleComponentToChildren : OnOscComponentToTarget
    {

        [SerializeField] OscScale oscScaleComp;
        void Start()
        {
            onOscType = typeof(OscScale);
            oscComp = oscScaleComp;
            SetTargets(transform);
            base.Start();
            for (int i = 0; i < targets.Count; i++)
            {
                GameObject go = targets[i];
                if (go.GetComponent<OscScale>() != null)
                {
                    OscScale oscScale = go.GetComponent<OscScale>();
                    oscScale.scalingVector = oscScaleComp.scalingVector;
                    oscScale.disableCollider = oscScaleComp.disableCollider;

                }
            }
        }

        void Update()
        {

        }
    }
}