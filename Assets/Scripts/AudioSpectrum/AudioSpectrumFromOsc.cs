using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using uOSC;

namespace AudioSpectrum{
    public class AudioSpectrumFromOsc : MonoBehaviour
    {
        [SerializeField]private uOscServer server;
        [SerializeField] string addressLevel = "/level";
        [SerializeField] string addressSpec = "/spectrum";
        [SerializeField] public int specSize = 256;
        [ReadOnly] public int level = 0;
        [HideInInspector] public int[] spectrum;

        void Awake(){
            spectrum = new int[specSize];
        }

        void Start(){
            server.onDataReceived.AddListener(OnDataReceived);
        }

        public float GetAverage(){
            float avrg = 0;
            foreach(int spec in spectrum){
                avrg += spec;
            }
            return avrg;
        }

        public List<float> GetReconstruct(int length)
        {
            List<float> reconstruct = new List<float>();
            int step = specSize / length;
            for(int i = 0; i < length; i++)
            {
                float sum = 0;
                for(int j = 0; j < step; j++)
                {
                    sum += spectrum[i * step + j];
                }
                reconstruct.Add(sum / step);
            }
            return reconstruct;
        }

        void OnDataReceived(Message message)
        {
            string receiveAddress = message.address;
            if(receiveAddress == addressSpec){
                for(int i = 0; i < specSize; i++){
                    if(message.values[i] is int){
                        spectrum[i] = (int)message.values[i];
                    }
                }
            }
            else if(receiveAddress == addressLevel){
                if(message.values[0] is int){
                    level = (int)message.values[0];
                }
            }
        }
    }
}