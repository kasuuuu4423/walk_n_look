using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


namespace UILine
{
    public class UILines : Graphic
    {
        public static int linenum = 10;
        public float[] weightMultiplies = new float[linenum];

        [SerializeField]
        private Vector2 startPosition;
        [SerializeField]
        private Vector2 endPosition;
        [SerializeField]
        private float _weight;


        private Vector2[] positions = new Vector2[linenum];

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            for(int i = 0; i < linenum; i++)
            {
                //if (weightMultiplies[i] == 0)
                //{
                //    weightMultiplies[i] = 1;
                //}
                float t = (float)i / (float)linenum;
                t += Random.Range(0.0f, 0.1f);
                Vector2 linePosition = Vector2.Lerp(startPosition, endPosition, t);
                AddVert(vh, new Vector2(startPosition.x, linePosition.y - _weight * weightMultiplies[i] / 2));
                AddVert(vh, new Vector2(startPosition.x, linePosition.y + _weight * weightMultiplies[i] / 2));
                AddVert(vh, new Vector2(endPosition.x, linePosition.y - _weight * weightMultiplies[i] / 2));
                AddVert(vh, new Vector2(endPosition.x, linePosition.y + _weight * weightMultiplies[i] / 2));
                int baseIndex = i * 4;
                vh.AddTriangle(baseIndex, baseIndex + 1, baseIndex + 2);
                vh.AddTriangle(baseIndex + 1, baseIndex + 2, baseIndex + 3);
            }
        }
        private void AddVert(VertexHelper vh, Vector2 pos)
        {
            var vert = UIVertex.simpleVert;
            vert.position = pos;
            vert.color = color;
            vh.AddVert(vert);
        }

        void Update()
        {
            SetVerticesDirty();
        }
    }
}