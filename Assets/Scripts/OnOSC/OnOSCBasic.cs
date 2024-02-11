using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOSCBasic : MonoBehaviour
{
    [SerializeField] public OSCReceive osc;
    [Header("指定なしの場合貼り付けたオブジェクト")]
    [SerializeField] public GameObject obj;
    [SerializeField] public float multiply = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (obj == null)
        {
            obj = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
