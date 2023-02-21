using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCrystal : MonoBehaviour
{
    public float ExpAmount;
    Renderer render;

    float speed = 20.0f;
    float acceleration = 2f;
    float maxSpeed = 100.0f;
    float destroyDistance = 0.05f;
    private float currentSpeed;
    Transform playerTransform;

    public bool isGathered = false;
    public void SetUpCrystal(float expLevel)
    {
        playerTransform=GameManager.Instance.playerMovement.PlayerTransform;
        render = GetComponent<Renderer>();
        switch (expLevel) 
        {
            case 1:
                {
                    ExpAmount = 5;
                    render.material.color = Color.white;
                    break;
                }
            case 2:
                {
                    ExpAmount = 10;
                    render.material.color = Color.green;
                    break;
                }
            case 3:
                {
                    ExpAmount = 20;
                    render.material.color = Color.yellow;
                    break;
                }
            case 5:
                {
                    ExpAmount = 40;
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
    private void Update()
    {
        if (isGathered)
        {
            FlyCrystalTowardsPlayer();
        }
    }
    public void FlyCrystalTowardsPlayer()
    {
            currentSpeed = speed;
            // Get direction towards player
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize();

            // Apply acceleration
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, speed, maxSpeed);

            // Move towards player
            transform.position += direction * currentSpeed * Time.deltaTime;
            DestroyWhenClose();

    }
    void DestroyWhenClose() 
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
