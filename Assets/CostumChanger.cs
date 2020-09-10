using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumChanger : MonoBehaviour
{
    public Material[] faceMaterials;
    public Material[] bodyMaterials;
    public Mesh[] hornMeshes;

    public GameObject playerAvatar;

    private SkinnedMeshRenderer faceSkinnedMR;
    private SkinnedMeshRenderer bodySkinnedMR;
    private SkinnedMeshRenderer hornSkinnedMR;

    public int indexFaceMaterial = -1;
    public int indexBodyMaterial = -1;
    public int indexHornMesh = -1;

    private void Start()
    {
        faceSkinnedMR = playerAvatar.transform.Find("Face").GetComponentInChildren<SkinnedMeshRenderer>();
        bodySkinnedMR = playerAvatar.transform.Find("Dragon_body").GetComponentInChildren<SkinnedMeshRenderer>();
        hornSkinnedMR = playerAvatar.transform.Find("Horn").GetComponentInChildren<SkinnedMeshRenderer>();
        indexFaceMaterial = GetMaterialIndex(faceMaterials, faceSkinnedMR);
        indexBodyMaterial = GetMaterialIndex(bodyMaterials, bodySkinnedMR);
        indexHornMesh = GetMeshIndex(hornMeshes);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Change Face");
            if (indexFaceMaterial >= faceMaterials.Length - 1)
            {
                indexFaceMaterial = 0;
                faceSkinnedMR.material = faceMaterials[indexFaceMaterial];
            }
            else
            {
                faceSkinnedMR.material = faceMaterials[indexFaceMaterial + 1];
                indexFaceMaterial++;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Change Body");
            if (indexBodyMaterial >= bodyMaterials.Length - 1)
            {
                indexBodyMaterial = 0;
                bodySkinnedMR.material = bodyMaterials[indexBodyMaterial];
            }
            else
            {
                bodySkinnedMR.material = bodyMaterials[indexBodyMaterial + 1];
                indexBodyMaterial++;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Change Horn");
            if (indexHornMesh >= hornMeshes.Length - 1)
            {
                indexHornMesh = 0;
                hornSkinnedMR.sharedMesh = hornMeshes[indexHornMesh];
            }
            else
            {
                hornSkinnedMR.sharedMesh = hornMeshes[indexHornMesh + 1];
                indexHornMesh++;
            }
        }
    }

    private int GetMaterialIndex(Material[] myMaterials, SkinnedMeshRenderer mySMR)
    {
        int index = -1;
        for (int i = 0; i < faceMaterials.Length; i++)
        {
            if (myMaterials[i].name + " (Instance)" == GetCurrentFaceMaterial(mySMR).name || myMaterials[i].name == GetCurrentFaceMaterial(mySMR).name)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    private int GetMeshIndex(Mesh[] myMeshes)
    {
        int index = -1;
        for (int i = 0; i < hornMeshes.Length; i++)
        {
            if (hornMeshes[i].name + " (Instance)" == GetCurrentHornMesh().name || hornMeshes[i].name == GetCurrentHornMesh().name)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    private Material GetCurrentFaceMaterial(SkinnedMeshRenderer mySMR)
    {
        return mySMR.materials[0];
    }

    private Mesh GetCurrentHornMesh()
    {
        return hornSkinnedMR.sharedMesh;
    }
}
