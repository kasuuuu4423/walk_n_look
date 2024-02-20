using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnOsc
{
    public class OnOscComponentToChild : MonoBehaviour
    {
        [Header("���I�u�W�F�N�g�ɑΏۃR���|�[�l���g��ǉ����Ďw��")]
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
