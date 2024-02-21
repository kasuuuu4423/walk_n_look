using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace UILine
{
    public class ManageUIOneLine : MonoBehaviour
    {
        List<GameObject> gameObjects = new List<GameObject>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        [Button("AddLine")]
        public void AddLine()
        {
            GameObject go = new GameObject();
        }
    }

}