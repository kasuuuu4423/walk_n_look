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
        [SerializeField] protected OnOSCBasic onOscComp;
        protected List<GameObject> targets = new List<GameObject>();
        protected List<GameObject> highTargets = new List<GameObject>();
        protected List<GameObject> midTargets = new List<GameObject>();
        protected List<GameObject> lowTargets = new List<GameObject>();


        // Start is called before the first frame update
       protected void Start()
        {
        
        }


        // Update is called once per frame
        void Update()
        {

        }

     

        protected void SetTargets<T>(Transform transform) where T : Component
        {

            targets = GetChildren.ByType<T>(transform);

        }

    }
}

