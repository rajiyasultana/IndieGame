using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private ColorTag p_colorTag;
    private PlayerColorSetter playerColorSetter;
    void Start()
    {
        p_colorTag = GetComponent<ColorTag>();
        playerColorSetter = GetComponent<PlayerColorSetter>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            ColorTag O_colorTag = other.GetComponent<ColorTag>();

            if (O_colorTag.colorID == p_colorTag.colorID)
            {
                GameManager.Instance.AddScore();
                Destroy(other.gameObject); // success

                playerColorSetter.RandomColorChanger();
            }
            else
            {
                GameManager.Instance.GameOver(); // fail
            }
        }
    }
}
