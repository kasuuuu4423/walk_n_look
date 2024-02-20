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

        [SerializeField] protected OscLightIntensity oscLightIntensityComp;
        void Start()
        {
            SetTargets<Light>(transform);

            base.Start();

            targets = targets.OrderBy(a => Guid.NewGuid()).ToList();
            for (int i = 0; i <= targets.Count / 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i * 3 + j < targets.Count)
                    {
                        if (j == 0)
                        {
                            targets[i * 3 + j] = InitComponent(targets[i * 3 + j], "/lmh/hi");
                            highTargets.Add(targets[i * 3 + j]);
                        }
                        else if (j == 1)
                        {
                            targets[i * 3 + j] = InitComponent(targets[i * 3 + j], "/lmh/mid");
                            midTargets.Add(targets[i * 3 + j]);
                        }
                        else if (j == 2)
                        {
                            targets[i * 3 + j] = InitComponent(targets[i * 3 + j], "/lmh/low");
                            lowTargets.Add(targets[i * 3 + j]);
                        }
                    }
                }
            }

        }

        GameObject InitComponent(GameObject go, string addr)
        {
            if (go.GetComponent<OscLightIntensity>() == null)
            {
                OscLightIntensity comp = go.AddComponent<OscLightIntensity>();
                comp.addr = addr;
            }
            return go;
        }

        void Update()
        {


        }
    }
}