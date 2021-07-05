using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public void CombineMeshes()
    {
        Quaternion oldRot = transform.rotation;// -5 5 5 / 10 20 0
        Vector3 oldPos = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        Mesh finalMesh = new Mesh();

        CombineInstance[] combiners = new CombineInstance[meshFilters.Length];// + -

        for (int i = 0; i < meshFilters.Length; i++)
        {
            if (meshFilters[i].transform == transform)
                continue;

            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = meshFilters[i].sharedMesh;
            combiners[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        finalMesh.CombineMeshes(combiners);

        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        transform.rotation = oldRot;
        transform.position = oldPos;

        for (int i = 0; i < transform.GetChildCount(); i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
