using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCrystal : MonoBehaviour
{
    public float ExpAmount;
    Renderer render;
    public void SetUpCrystal(float expLevel)
    {
        render = GetComponent<Renderer>();
        switch (expLevel) 
        {
            case 1:
                {
                    ExpAmount = 10;
                    render.material.color = Color.white;
                    break;
                }
            case 2:
                {
                    ExpAmount = 20;
                    render.material.color = Color.green;
                    break;
                }
            case 3:
                {
                    ExpAmount = 30;
                    render.material.color = Color.yellow;
                    break;
                }
            case 5:
                {
                    ExpAmount = 50;
                    render.material.color = Color.blue;
                    break;
                }
            case 4://boss only
                {
                    ExpAmount = 100;
                    render.material.color = Color.red;
                    break;
                }
        }
    }
}
