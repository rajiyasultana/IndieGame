using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private float spawnInterval = 1.5f;
    private float spawnZOffset = 20f;       //Distance from player
    private float xMin = -3f, xMax = 3f;

    private Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(xMin, xMax);
        Vector3 spawnPos = new Vector3(randomX, player.position.y, player.position.z + spawnZOffset);
        
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
