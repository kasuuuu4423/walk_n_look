using System.Collections.Generic;
using TypeInspector;
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
        for (int i = 0; i < targets.Count; i++)
        {
            GameObject go = targets[i];

            OnOSCBasic childComp = go.AddComponent<OnOSCBasic>();
            childComp.osc = onOscComp.osc;
            childComp.multiply = onOscComp.multiply;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
