using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    private int score = 0;
    private float time = 0f;
    void Awake()
    {
        Instance = this;
    }

    
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = Mathf.FloorToInt(time).ToString() + "s";

    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        
    }
}
