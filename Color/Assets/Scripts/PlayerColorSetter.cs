using UnityEngine;

public class PlayerColorSetter : MonoBehaviour
{
    public Color[] colorPalette;
    private Renderer rend;
    private ColorTag colorTag;

    void Start()
    {
        rend = GetComponent<Renderer>();
        colorTag = GetComponent<ColorTag>();
        int colorIndex = Random.Range(0, colorPalette.Length);
        rend.material.color = colorPalette[colorIndex];

        colorTag.colorID = colorIndex;
    }

    public void RandomColorChanger()
    {
        int colorIndex = Random.Range(0, colorPalette.Length);
        rend.material.color = colorPalette[colorIndex];

        colorTag.colorID = colorIndex;
    }
}
