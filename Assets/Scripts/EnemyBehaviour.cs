using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AIBehavior;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 10;
    public float maxHealth = 10f;
    public float armor = 5;
    public float speed = 10f;
    public float attackPower = 5;
    private NavMeshAgent agent;

    public PlayerMovement player;
    public float distanceToPlayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = Random.Range(0.5f, 2f);
        player = GameManager.Instance.playerMovement;
    }
    private void Update()
    {
        Destination();        
    }
    private void Destination()
    {
        agent.destination = player.PlayerTransform.position;
        agent.speed = speed;
        distanceToPlayer = agent.remainingDistance;
        if (agent.remainingDistance>=60f)
        {
            Debug.Log("Denied");
            Destroy(this.gameObject);
        }
    }
    public void Death()
    {
        Debug.Log("Died");
        Destroy(this.gameObject);
    }
    public void ApplyDamage(float amount) 
    {
        health -= amount;
        if (health<=0)
        {
            Death();
        }
    }
}
