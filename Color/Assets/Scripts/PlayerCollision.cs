using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Renderer playerRenderer;
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Renderer obstacleRenderer = other.GetComponent<Renderer>();

            if (obstacleRenderer.material.color == playerRenderer.material.color)
            {
                GameManager.Instance.AddScore();
                Destroy(other.gameObject); // success
            }
            else
            {
                GameManager.Instance.GameOver(); // fail
            }
        }
    }
}
