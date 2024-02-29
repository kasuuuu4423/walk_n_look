using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UILine
{
    public class RandomSortUILine : MonoBehaviour
    {
        GameObject[] children;
        Vector2[] positions;

        void Start()
        {
            children = new GameObject[transform.childCount];
            positions = new Vector2[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                children[i] = transform.GetChild(i).gameObject;
                positions[i] = children[i].GetComponent<RectTransform>().anchoredPosition;  
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        [Button("RandomSort")]
        public void RandomSort()
        {
            for (int i = 0; i < children.Length; i++)
            {
                int randomIndex = Random.Range(0, children.Length);
                GameObject temp = children[randomIndex];
                children[randomIndex] = children[i];
                children[i] = temp;
            }
            for (int i = 0; i < children.Length; i++)
            {
                children[i].transform.SetSiblingIndex(i);
                children[i].GetComponent<RectTransform>().anchoredPosition = positions[i];
            }
        }
    }
}
