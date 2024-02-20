using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityOSC;
using UnityEngine.SceneManagement;
using uOSC;

public class OSCReceive : MonoBehaviour
{
    public string address;
    
    public string name;
    public float value;
    //private long lastTimeStamp;
    //private OSCServer oscServer;
    // Start is called before the first frame update
    public uOscServer server;
    void Start()
    {
        //OSCHandler.Instance.Init();
        //oscServer = OSCHandler.Instance.CreateServer("local", port);
        server = GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);
        //lastTimeStamp = -1;
    }

    void OnDataReceived(Message message)
    {
        address = message.address;
        foreach(var val in message.values)
        {
            int tmpVal = 0;
            if(val is string) name = (string)val;
            else if(val is int ) value = (int)val;
            else if(val is null)
            {
                value = -1;
            }
        }
        //OSCHandler.Instance.UpdateLogs();
        // foreach (KeyValuePair<string, ServerLog> item in OSCHandler.Instance.Servers) {
        //     for (int i=0; i < item.Value.packets.Count; i++) {
        //         if (lastTimeStamp < item.Value.packets[i].TimeStamp) {
        //             lastTimeStamp = item.Value.packets[i].TimeStamp;
        //             address = item.Value.packets[i].Address;
        //             name = (string)item.Value.packets[i].Data[0];
        //             if(item.Value.packets[i].Data.Count > 1){
        //                 value = System.Convert.ToSingle(item.Value.packets[i].Data[1]);
        //             }
        //             else{
        //                 value = -1;
        //             }
        //         }
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // OSCHandler.Instance.UpdateLogs();
        // foreach (KeyValuePair<string, ServerLog> item in OSCHandler.Instance.Servers) {
        //     for (int i=0; i < item.Value.packets.Count; i++) {
        //         if (lastTimeStamp < item.Value.packets[i].TimeStamp) {
        //             lastTimeStamp = item.Value.packets[i].TimeStamp;
        //             address = item.Value.packets[i].Address;
        //             name = (string)item.Value.packets[i].Data[0];
        //             if(item.Value.packets[i].Data.Count > 1){
        //                 value = System.Convert.ToSingle(item.Value.packets[i].Data[1]);
        //             }
        //             else{
        //                 value = -1;
        //             }
        //         }
        //     }
        // }
    }

    public bool CheckAddress(string addr)
    {
        return addr == address;
    }

    public bool CheckName(string name){
        return name == this.name;
    }

    // public void Close()
    // {
    //     oscServer.Close();
    // }

    // void SceneUnloaded (Scene thisScene) {
    //     oscServer.Close();
    //     oscServer = null;
    // }
}