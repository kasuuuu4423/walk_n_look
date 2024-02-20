using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace OnOsc
{
    public class OscMatEmission : OnOSCBasic
    {
        Material mat;
        Color initialColor;
        // float scaleSpeed = 0.1f;

        void Start()
        {
            base.Start();
            mat = obj.GetComponent<Renderer>().material;
            if( mat != null )
            {
                initialColor = mat.GetColor("_EmissionColor");
            }
        }

        void Update()
        {
            if (mat != null)
            {
                base.Update();
                float intensity = value * multiply;
                mat.SetColor("_EmissionColor", new Color(initialColor.r * intensity, initialColor.r * intensity, initialColor.r * intensity));
                //StartCoroutine(ScaleObject(value));
            }
        }
    }

}
