using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public float health = 100;
    public float armor = 5;
    public float speed = 1;
    public float attackPower = 10;

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            Debug.Log("Ouch");
        }
    }
}
