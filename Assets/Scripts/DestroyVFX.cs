using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVFX : MonoBehaviour
{
    ParticleSystem particleSystem;
    public bool useDuration = false;
    public float duration;
    private bool flag =true;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (useDuration==false) {
            if (particleSystem.isStopped)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (flag)
            {
                StartCoroutine(DelayDestroy());
                flag = false;
            }
        }
        
    }
    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(duration);
    }
}
