using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AIBehavior;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 10;
    public float armor = 5;
    public float speed = 10f;
    public float attackPower = 5;
    private NavMeshAgent agent;

    public PlayerMovement player;

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
    }
}
