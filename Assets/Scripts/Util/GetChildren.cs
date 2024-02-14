using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public static class GetChildren
    {
        public static List<GameObject> ByType<T>(Transform transform)
        {
            List<GameObject> children = new List<GameObject>();
            if (transform.gameObject.GetComponent<T>() == null && transform.childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    Debug.Log(child);
                    children.AddRange(ByType<T>(child));
                }
            }
            else if(transform.gameObject.GetComponent<T>() != null)
            {
                children.Add(transform.gameObject);
            }
            return children;
        }
    }
}