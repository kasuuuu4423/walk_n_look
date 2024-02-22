using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnOsc
{
    public class OnOSCBasic : MonoBehaviour
    {
        [SerializeField] public OSCReceiveLMH osc;
        [SerializeField] public LMH.LMHType type;
    //[Header("�w��Ȃ��̏ꍇ���t�����I�u�W�F�N�g")]
    [SerializeField] public GameObject obj;
        [SerializeField] public float multiply = 1.0f;
        [SerializeField] public float value = 1;
        [SerializeField] public string addr;
        // Start is called before the first frame update
        protected void Start()
        {
            if (obj == null)
            {
                obj = gameObject;
            }
        }

        // Update is called once per frame
        protected void Update()
        {
            if(type == LMH.LMHType.L)
            {
                value = osc.l.value;
            }
            else if(type == LMH.LMHType.M)
            {
                value = osc.m.value;
            }
            else if(type == LMH.LMHType.H)
            {
                value = osc.h.value;
            }
        }
    }

}