using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackRocket : MonoBehaviour
{
    protected float speed;
    public Vector3 randomPostition;
    public Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime;
        speed = speed % 5f;
        transform.position = MathParabola.Parabola(startingPosition, randomPostition,5f,speed/5f);
        
    }
}
