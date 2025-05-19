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
    [SerializeField] TextMeshProUGUI highScoreCounter;
    [SerializeField] TextMeshProUGUI bestTimeCounter;

    private int score = 0;
    private float time = 0;
    private bool isGameOver;
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SaveManager.LoadData();
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

        GameData existingData = SaveManager.LoadData();


        int finalScore = score;
        float finalTime = time;
        // Compare and update highscore and best time
        int highScore = Mathf.Max(finalScore, existingData.highScore);
        float bestTime = Mathf.Max(finalTime, existingData.bestTime);

        scoreTextCounter.text = finalScore.ToString();
        timeTextCounter.text = finalTime.ToString() + "`s";
        highScoreCounter.text = finalScore.ToString();
        bestTimeCounter.text = finalTime.ToString() + "`s";


        GameData data = new GameData
        {
            score = finalScore,
            time = finalTime,
            highScore = highScore,
            bestTime = bestTime
        };

        SaveManager.SaveData(data);
    }
}
