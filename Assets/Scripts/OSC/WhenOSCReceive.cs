using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class WhenOSCReceive : MonoBehaviour
{
    public string addr;
    public string name;
    public UnityEvent<float> targetFunction;
    public UnityEvent targetVoidFunction;
    private OSCReceive osc;

    void Start()
    {
        osc = gameObject.GetComponent<OSCReceive>();
    }

    void Update()
    {
        if(osc.CheckAddress(addr) && osc.CheckName(name))
        {
            if(osc.value != -1) targetFunction.Invoke(osc.value);
            else targetVoidFunction.Invoke();
        }
    }
}