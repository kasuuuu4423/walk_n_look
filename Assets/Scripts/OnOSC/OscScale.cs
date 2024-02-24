using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnOsc
{
    public class OscScale : OnOSCBasic
    {
        [SerializeField] public Vector3 scalingVector;
        [SerializeField] public bool disableCollider = false;
        Vector3 initialScale;
        bool isScaling = false;

        void Start()
        {
            base.Start();
            initialScale = obj.transform.localScale;
            if(GetComponent<Collider>() != null)
                GetComponent<Collider>().enabled = !disableCollider;
            else
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    Transform child = obj.transform.GetChild(i);
                    if (child.gameObject.GetComponent<Collider>() != null)
                        child.gameObject.GetComponent<Collider>().enabled = !disableCollider;
                    else if (child.childCount > 0)
                    {
                        for (int j = 0; j < child.childCount; j++)
                        {
                            Transform grandchild = child.GetChild(j);
                            if (grandchild.gameObject.GetComponent<Collider>() != null)
                                grandchild.gameObject.GetComponent<Collider>().enabled = !disableCollider;
                        }
                    }
                }
        }

        void Update()
        {
            float randomNoise = 0;
            if (!isScaling)
            {
                base.Update();
                randomNoise = Random.Range(-1f * value * 0.05f*multiply, value * 0.05f*multiply); ;
            }
            Vector3 targetScale = new Vector3(
                initialScale.x + (scalingVector.x == 1 ? value : 0) * multiply + randomNoise,
                initialScale.y + (scalingVector.y == 1 ? value : 0) * multiply + randomNoise,
                initialScale.z + (scalingVector.z == 1 ? value : 0) * multiply + randomNoise
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