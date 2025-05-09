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

    [SerializeField] GameObject gameOverMenu;
    [SerializeField] TextMeshProUGUI scoreTextCounter;
    [SerializeField] TextMeshProUGUI timeTextCounter;

    private int score = 0;
    private float time = 0f;
    private bool isGameOver;
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
        isGameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;

        int finalScore = score;
        float finalTime = time;

        scoreTextCounter.text = finalScore.ToString();
        timeTextCounter.text = finalTime.ToString("F2") + "s";

        GameData data = new GameData
        {
            score = finalScore,
            time = finalTime
        };

        SaveManager.SaveData(data);
    }
}
