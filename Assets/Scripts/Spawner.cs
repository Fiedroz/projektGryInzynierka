using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour//GameManager.Instance.playerMovement.PlayerTransform.position
{
    public GameObject cubePrefab; // drag the cube prefab into this field in the Inspector
    public float radius = 5f; // radius of the circle
    public int numCubes = 10; // number of cubes to spawn
    public float cubeDistance = 0.5f; // distance between each cube
    public float raycastDistance = 10f; // distance to check for collisions
    public float height = 1f;
    RaycastHit hit;
    public LayerMask groundLayer;
    //public Vector3 offset; // offset to check spawn point

    void Start()
    {
        StartCoroutine(SpawnTiming());
    }
    IEnumerator SpawnTiming()
    {
        for (int i=0;i<5;i++)
        {
            yield return new WaitForSeconds(5);
            SpawnBasicEnemy();
        }
        yield return new WaitForSeconds(1);

    }
    private void SpawnBasicEnemy()
    {
        for (int i = 0; i < numCubes; i++)
        {
            float angle = Random.Range(0f, 2 * Mathf.PI); // generate a random angle
            Vector3 spawnPos = GameManager.Instance.playerMovement.spawnTransform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * (radius - (cubeDistance * i)); // calculate spawn position using trigonometry and offsetting the radius by i*cubeDistance
            //spawnPos += offset;
            // check if the spawn point is on a ground plane
            if (Physics.Raycast(spawnPos, Vector3.down, out hit, height, groundLayer))
            {
                Instantiate(cubePrefab, spawnPos, Quaternion.identity); // spawn the cube on the ground plane
            }
        }
    }
}
