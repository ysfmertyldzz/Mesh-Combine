using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int test;

    public GameObject prefab;

    public Vector2 minPos;
    public Vector2 maxPos;

    private void Start()
    {
        for (int i = 0; i < test; i++)
        {
            GameObject obj = Instantiate(prefab,new Vector2(Random.RandomRange(minPos.x, maxPos.x), Random.RandomRange(minPos.y, maxPos.y)),Quaternion.identity,this.transform);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<MeshCombiner>().CombineMeshes();

    }
}
