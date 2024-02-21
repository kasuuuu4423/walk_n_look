using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public static class GetChildren
    {
        public static List<GameObject> ByType<T>(Transform transform) where T : Component
        {
            List<GameObject> children = new List<GameObject>();
            if (transform.gameObject.GetComponent<T>() == null && transform.childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    children.AddRange(ByType<T>(child));
                }
            }
            else if(transform.gameObject.GetComponent<T>() != null)
            {
                children.Add(transform.gameObject);
            }
            return children;
        }

        public static List<GameObject> ByMaterial(Transform transform, Material[] mats, string suffix)
        {
            List<GameObject> children = new List<GameObject>();
            Renderer renderer = transform.gameObject.GetComponent<Renderer>();
            if(renderer != null)
            {
                bool isTarget = false;
                for(int i = 0; i < mats.Length; i++)
                {
                    if(renderer.material.name == mats[i].name + suffix)
                    {
                        children.Add(transform.gameObject);
                        isTarget = true;
                    }
                }
                if (isTarget)
                {
                    children.Add(transform.gameObject);
                }
            }
            if (transform.childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    children.AddRange(ByMaterial(child, mats, suffix));
                }
            }
            return children;
        }
    }
}