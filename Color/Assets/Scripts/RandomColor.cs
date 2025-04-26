using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomColor : MonoBehaviour
{
    private TextMeshProUGUI[] allTexts;
    [SerializeField] private float interval = 1f;
    void Start()
    {
        allTexts = FindObjectsOfType<TextMeshProUGUI>(true);
        InvokeRepeating(nameof(ColorChange), 0, interval);
    }

    private void ColorChange()
    {
        foreach (var text in allTexts)
        {
            if (text != null)
            {
                Color randomColor = new Color(Random.value, Random.value, Random.value);
                text.color = randomColor;
            }
        }
    }
}
