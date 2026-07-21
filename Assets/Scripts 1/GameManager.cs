using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScore();
        gameOverPanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}