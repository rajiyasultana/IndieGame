using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float interval = 1f;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("ColorChange", 0, interval);
    }

    private void ColorChange()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        if(text != null)
        {
            text.color = randomColor;
        }

        
    }
}
