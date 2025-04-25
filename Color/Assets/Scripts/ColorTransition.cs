using UnityEngine;
using TMPro;

public class ColorTransition : MonoBehaviour
{
    public TextMeshProUGUI TextMeshPro;
    public Color[] colors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    public float time;

    
    void Start()
    {
        TextMeshPro = GetComponent<TextMeshProUGUI>();    
    }
    
    void Update()
    {
        Transition();
    }

    void Transition()
    {
        targetPoint += Time.deltaTime;
        TextMeshPro.color = Color.Lerp(colors[currentColorIndex], colors[targetColorIndex], targetPoint);
        if(targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if(targetColorIndex == colors.Length)
            {
                targetColorIndex = 0;
            }
        }
    }

}
