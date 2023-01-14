using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public float health = 100;
    public float armor = 5;
    public float speed = 1;
    public float attackPower = 10;
    bool alive = true;

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            Debug.Log("Ouch "+other.GetComponent<EnemyBehaviour>().attackPower);
            if (health>0) {
                health -= other.GetComponent<EnemyBehaviour>().attackPower;
            }
            else
            {
                Death();
            }
        }
    }
    public void Death()
    {
        Debug.Log("YOU DIED");
        health = 0;
        alive = false;
    }
}
