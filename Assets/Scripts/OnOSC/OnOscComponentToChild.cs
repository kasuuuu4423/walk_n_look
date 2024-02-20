using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnOsc
{
    public class OnOscComponentToChild : MonoBehaviour
    {
        [Header("同オブジェクトに対象コンポーネントを追加して指定")]
        [SerializeField] OnOSCBasic onOscComp;

        void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                OnOSCBasic childComp = transform.GetChild(i).gameObject.AddComponent<OnOSCBasic>();
                childComp.osc = onOscComp.osc;
                childComp.multiply = onOscComp.multiply;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
