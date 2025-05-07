using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private float spawnInterval = 1.2f;
    private float spawnZOffset = 20f;       //Distance from player
    private float xMin = -2f, xMax = 2f;

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
        
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        //Assign random color
        Renderer rend = newObstacle.GetComponent<Renderer>();
        if (rend != null )
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            rend.material.color = randomColor;
            
        }
    }
}
