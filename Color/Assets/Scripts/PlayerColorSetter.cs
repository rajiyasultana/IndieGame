using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSetter : MonoBehaviour
{
    public Color[] obstacleColors;
    private Renderer rend;
    private ColorTag colorTag;

    void Start()
    {
        int colorIndex = Random.Range(0, obstacleColors.Length);

        rend = GetComponent<Renderer>();
        rend.material.color = obstacleColors[colorIndex];

        colorTag = GetComponent<ColorTag>();
        colorTag.colorID = colorIndex;
    }
}
