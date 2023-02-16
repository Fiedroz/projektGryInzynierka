using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AIBehavior;

public class EnemyBehaviour : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float armor;
    public float speed;
    public float attackPower;
    public float expLevel;
    private NavMeshAgent agent;

    public PlayerMovement player;
    public GameObject expPrefab;
    public float distanceToPlayer;

    Renderer enemyRenderer;
    Color defalutColor;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = Random.Range(0.5f, 2f);
        player = GameManager.Instance.playerMovement;
        enemyRenderer = GetComponent<Renderer>();
        defalutColor = enemyRenderer.material.color;
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
        GameObject exp = Instantiate(expPrefab,transform.position,transform.rotation);
        exp.GetComponent<ExpCrystal>().SetUpCrystal(expLevel);
        Destroy(this.gameObject);
    }
    public void ApplyDamage(float amount) 
    {
        health -= amount;
        StartCoroutine(TakeDamage());
    }
    public IEnumerator ApplySlow(float duration, float slowPower)
    {
        float defalutSpeed = speed;
        speed -= slowPower;
        yield return new WaitForSeconds(duration);
        speed = defalutSpeed;

    }
    private IEnumerator TakeDamage()
    {
        float t = 0;
        float fadeTime = 0.5f;
        if (health <= 0)
        {
            speed -= 100;
            fadeTime = 0;
        }
        enemyRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            enemyRenderer.material.color = Color.Lerp(Color.white, defalutColor, t);
            yield return null;
        }
        if (health <= 0)
        {
            Death();
        }
    }
}
