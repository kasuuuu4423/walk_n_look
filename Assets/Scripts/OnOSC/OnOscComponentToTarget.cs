using System.Collections.Generic;
using System.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine;
using Util;

namespace OnOsc
{
    public class OnOscComponentToTarget  : MonoBehaviour
    {
        //[Header("���I�u�W�F�N�g�ɑΏۃR���|�[�l���g��ǉ����Ďw��")]
        protected OnOSCBasic oscComp;
        protected Type onOscType;
        protected List<GameObject> targets = new List<GameObject>();
        protected List<GameObject> highTargets = new List<GameObject>();
        protected List<GameObject> midTargets = new List<GameObject>();
        protected List<GameObject> lowTargets = new List<GameObject>();


        // Start is called before the first frame update
        protected void Start()
        {
            targets = targets.OrderBy(a => Guid.NewGuid()).ToList();
            for (int i = 0; i <= targets.Count / 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i * 3 + j < targets.Count)
                    {
                        if (j == 0)
                        {
                            targets[i * 3 + j] = InitComponent(targets[i * 3 + j], "/lmh/hi", onOscType);
                            highTargets.Add(targets[i * 3 + j]);
                        }
                        else if (j == 1)
                        {
                            targets[i * 3 + j] = InitComponent(targets[i * 3 + j], "/lmh/mid", onOscType);
                            midTargets.Add(targets[i * 3 + j]);
                        }
                        else if (j == 2)
                        {
                            targets[i * 3 + j] = InitComponent(targets[i * 3 + j], "/lmh/low", onOscType);
                            lowTargets.Add(targets[i * 3 + j]);
                        }
                    }
                }
            }
        }


        // Update is called once per frame
        void Update()
        {

        }

        GameObject InitComponent(GameObject go, string addr, Type type)
        {
            if (go.GetComponent(type) == null)
            {
                OnOSCBasic comp = (OnOSCBasic)go.AddComponent(type);
                comp.addr = addr;
                comp.osc = oscComp.osc;
                comp.multiply = oscComp.multiply;
            }
            return go;
        }

        protected void SetTargets(Transform transform)
        {
            targets = new List<GameObject>();
            for (int i = 0; i < transform.childCount; i++)
            {
                targets.Add(transform.GetChild(i).gameObject);
            }
        }

        protected void SetTargetsByType<T>(Transform transform) where T : Component
        {
            targets = GetChildren.ByType<T>(transform);

        }
        
        protected void SetTargetByMaterial(Transform transform, Material[] mats)
        {
            targets = GetChildren.ByMaterial(transform, mats);
        }
    }
}

