using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
