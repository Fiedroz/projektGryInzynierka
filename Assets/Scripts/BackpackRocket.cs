using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackRocket : MonoBehaviour
{
    protected float speed;
    public Vector3 randomPostition;
    public Vector3 startingPosition;
    void Update()
    {
        speed += Time.deltaTime;
        speed = speed % 5f;
        transform.position = MathParabola.Parabola(startingPosition, randomPostition,5f,speed/5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
