using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnOsc
{
    public class OscScale : OnOSCBasic
    {
        Vector3 initialScale;

        void Start()
        {
            initialScale = obj.transform.localScale;
        }

        void Update()
        {
            if (osc.address == "/gain")
            {
                float value = osc.value;
                obj.transform.localScale = new Vector3(
                    initialScale.x + value,
                    initialScale.y + value,
                    initialScale.z + value
                    );
            }
        }
    }

}