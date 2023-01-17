using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVFX : MonoBehaviour
{
    ParticleSystem particleSystem;
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (particleSystem.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
