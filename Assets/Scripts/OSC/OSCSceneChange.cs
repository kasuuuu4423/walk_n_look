using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uOSC;
using UnityEngine.SceneManagement;

public class OSCSceneChange : MonoBehaviour
{
    [SerializeField] uOscServer server;
    [SerializeField] string address;

    void Start() {
        server.onDataReceived.AddListener(OnDataReceived);
    }

    void OnDataReceived(Message message)
    {
        address = message.address;
        foreach (var val in message.values)
        {
            if(val is string)
            {
                string name = (string)val;
                Debug.Log(name);
                SceneManager.LoadSceneAsync(name);
            }
        }
    }
}
