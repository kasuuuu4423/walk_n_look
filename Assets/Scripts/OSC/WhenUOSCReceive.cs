using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using uOSC;

public class WhenUOSCReceive : MonoBehaviour
{
    public string addr;
    public string name;
    public bool useName = false;
    [ReadOnly]
    public string receiveName = "";
    public UnityEvent<float> targetFunction;
    public UnityEvent targetVoidFunction;
    private OSCReceive osc;
    private uOscServer server;

    void Start()
    {
        osc = gameObject.GetComponent<OSCReceive>();
        server = gameObject.GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);
    }

    void Update()
    {
    }

    void OnDataReceived(Message message)
    {
        string address = message.address;
        foreach (var val in message.values)
        {
            if(val is string)
            {
                string n = (string)val;
                receiveName = n;
                if(address == addr && n == name)
                {
                    targetVoidFunction.Invoke();
                }
            }
            else if (!useName && address == addr)
            {
                targetVoidFunction.Invoke();
            }
            else if(val is int)
            {
                int intVal = (int)val;
                targetFunction.Invoke((float)intVal);
            }
        }
    }
}