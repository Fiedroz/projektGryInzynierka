using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject[] vfx;
    
    public void SpawnVFX(int id, Vector3 position,Transform parent)
    {
        GameObject vfxObject = Instantiate(vfx[id],position,Quaternion.identity,parent);
    }
}
