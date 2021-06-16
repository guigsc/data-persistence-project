using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public static MainUIHandler Instance;

    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateHighScore(string playerName, int highScore)
    {
        if (string.IsNullOrEmpty(playerName) && highScore == 0)
        {
            highScoreText.text = $"There is no best score";
        }
        else
        {
            highScoreText.text = $"BestScore [ {playerName} ]: {highScore}";
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
