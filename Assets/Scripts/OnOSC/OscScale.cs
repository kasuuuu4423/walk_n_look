using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnOsc
{
    public class OscScale : OnOSCBasic
    {
        [SerializeField] public Vector3 scalingVector;
        Vector3 initialScale;
        bool isScaling = false;

        void Start()
        {
            base.Start();
            initialScale = obj.transform.localScale;
        }

        void Update()
        {
            if (!isScaling)
            {
                base.Update();
            }
            Vector3 targetScale = new Vector3(
                initialScale.x + (scalingVector.x == 1 ? value : 0),
                initialScale.y + (scalingVector.y == 1 ? value : 0),
                initialScale.z + (scalingVector.z == 1 ? value : 0)
                );
            StartCoroutine(ScaleOverTime(targetScale, 10));
            //obj.transform.localScale = 
        }


        IEnumerator ScaleOverTime(Vector3 target, int frames)
        {
            isScaling = true;
            Vector3 startScale = transform.localScale;
            Vector3 deltaScale = (target - startScale) / frames;

            for (int i = 0; i < frames; i++)
            {
                transform.localScale += deltaScale;
                yield return null; // Wait for next frame
            }

            // Ensure the target scale is set exactly at the end
            transform.localScale = target;
            isScaling = false;
        }
    }
}