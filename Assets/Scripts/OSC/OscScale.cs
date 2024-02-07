using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;

namespace OnOsc
{
    public class OscScale : MonoBehaviour
    {
        [SerializeField] OSCReceive osc;
        [SerializeField] GameObject obj;
        Vector3 initialScale;
        // float scaleSpeed = 0.1f;

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
                //StartCoroutine(ScaleObject(value));
            }
        }

        // IEnumerator ScaleObject(float value)
        // {
        //     Vector3 initialScale = obj.transform.localScale;
        //     Vector3 finalScale = targetScale * value;

        //     float elapsedTime = 0f;
        //     while (elapsedTime < scaleSpeed)
        //     {
        //         obj.transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / scaleSpeed);
        //         elapsedTime += Time.deltaTime;
        //         yield return null;
        //     }

        //     obj.transform.localScale = finalScale;
        // }
    }

}