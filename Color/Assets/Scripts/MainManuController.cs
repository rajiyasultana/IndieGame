using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManuController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI bestTimeText;

    private void Awake()
    {
        GameData data = SaveManager.LoadData();
        highScoreText.text = "High Score: " + data.highScore;
        bestTimeText.text = "Best Time: " + data.bestTime.ToString() + "`s";
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
