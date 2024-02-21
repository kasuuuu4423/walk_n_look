using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioSpectrum;
using CustomMath;

namespace UILine
{
    [RequireComponent(typeof(UILines))]
    public class UILinesWithOSC : MonoBehaviour
    {
        [SerializeField] UILines lines;
        [SerializeField] AudioSpectrumFromOsc spectrum;
        List<float> reconstruct = new List<float>();
        // Start is called before the first frame update
        void Start()
        {
            lines = GetComponent<UILines>();
            reconstruct = spectrum.GetReconstruct(UILines.linenum);
        }

        // Update is called once per frame
        void Update()
        {
            reconstruct = spectrum.GetReconstruct(UILines.linenum);
            for(int i = 0; i < UILines.linenum; i++)
            {
                lines.weightMultiplies[i] = Math.Map(reconstruct[i], 0, 255, 0, 25);
            }
        }
    }
}