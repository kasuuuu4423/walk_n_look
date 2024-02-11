using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class OscMatEmission : MonoBehaviour
{
    [SerializeField] OSCReceive osc;
    [SerializeField] GameObject obj;
    [SerializeField] float multiply;
    Material mat;
    Color initialColor;
    // float scaleSpeed = 0.1f;

    void Start()
    {

        mat = GetComponent<Renderer>().material;
        initialColor = mat.GetColor("_EmissionColor");
    }

    void Update()
    {
        if (osc.address == "/gain")
        {
            float value = osc.value * multiply;
            mat.SetColor("_EmissionColor", new Color(initialColor.r + value, initialColor.r + value, initialColor.r + value));
            //StartCoroutine(ScaleObject(value));
        }
    }
}
