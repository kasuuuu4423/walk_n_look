using System.Collections.Generic;
using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine;
using Util;

public class OnOscComponentToTarget<T> : MonoBehaviour
{
    [Header("���I�u�W�F�N�g�ɑΏۃR���|�[�l���g��ǉ����Ďw��")]
    [SerializeField] OnOSCBasic onOscComp;
    List<GameObject> targets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        targets = GetChildren.ByType<T>(transform);
        targets = targets.OrderBy(a => Guid.NewGuid()).ToList();
        for (int i = 0; i <= targets.Count/3; i++)
        {
            if(i == targets.Count/3){
                if(targets.Count%3 == 0){

                    //GameObject HighGo = targets[i*3];
                    //GameObject MidGo = targets[i*3+1];
                    //GameObject LowGo = targets[i*3+2];

                }else if(targets.Count%3 == 1){

                    GameObject HighGo = targets[i*3];
                    //GameObject MidGo = targets[i*3+1];
                    //GameObject LowGo = targets[i*3+2];

                }else if(targets.Count%3 == 2){

                    GameObject HighGo = targets[i*3];
                    GameObject MidGo = targets[i*3+1];
                    //GameObject LowGo = targets[i*3+2];

                }else{

                    GameObject HighGo = targets[i*3];
                    GameObject MidGo = targets[i*3+1];
                    GameObject LowGo = targets[i*3+2];

                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
