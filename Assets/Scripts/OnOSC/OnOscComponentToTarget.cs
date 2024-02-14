using System.Collections.Generic;
using TypeInspector;
using Unity.VisualScripting;
using UnityEngine;
using Util;

public class OnOscComponentToTarget<T> : MonoBehaviour
{
    [Header("同オブジェクトに対象コンポーネントを追加して指定")]
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
