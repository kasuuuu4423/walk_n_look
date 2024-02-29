using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlockFloor : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] Vector2 size;
    GameObject[] blocks;

    private void Awake()
    {
        blocks = new GameObject[(int)size.x * (int)size.y];
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Vector3 pos = new Vector3((i - size.x / 2) * blockPrefab.transform.localScale.x, 0, (j - size.y / 2) * blockPrefab.transform.localScale.z);
                Vector3 scale = blockPrefab.transform.localScale;
                GameObject block = Instantiate(blockPrefab);
                block.transform.parent = transform;
                block.transform.localPosition = pos;
                block.transform.localScale = scale;
                block.transform.localRotation = Quaternion.Euler(0, Random.Range(0,100) > 50? -90:0, 0);
                block.SetActive(true);
                block.GetComponent<Renderer>().material = blockPrefab.GetComponent<Renderer>().material;
                blocks[i * (int)size.y + j] = block;
            }
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
