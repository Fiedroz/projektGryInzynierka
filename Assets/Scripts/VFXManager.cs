using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject[] vfx;
    
    public GameObject SpawnVFX(int id, Vector3 position,Transform parent)
    {
        GameObject vfxObject = Instantiate(vfx[id],position,Quaternion.identity,parent);
        return vfxObject;
    }
    public GameObject SpawnVFX(int id, Vector3 position)
    {
        GameObject vfxObject = Instantiate(vfx[id], position, Quaternion.identity);
        return vfxObject;
    }
}
