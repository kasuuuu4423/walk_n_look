using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityOSC;
using UnityEngine.SceneManagement;
using uOSC;

public class OSCReceiveLMH : MonoBehaviour
{
    [SerializeField] string lAddress;
    [SerializeField] string mAddress;
    [SerializeField] string hAddress;
    [HideInInspector] public LMH l;
    [HideInInspector] public LMH m;
    [HideInInspector] public LMH h;
    public uOscServer server;
    public string address;

    void Start()
    {
        l = new LMH(LMH.LMHType.L, lAddress);
        m = new LMH(LMH.LMHType.M, mAddress);
        h = new LMH(LMH.LMHType.H, hAddress);
        server = GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);
    }

    void OnDataReceived(Message message)
    {
        address = message.address;
        if(address == l.address)
        {
            l.value = (int)message.values[0];
        }
        else if(address == m.address)
        {
            m.value = (int)message.values[0];
        }
        else if(address == h.address)
        {
            h.value = (int)message.values[0];
        }
    }
}