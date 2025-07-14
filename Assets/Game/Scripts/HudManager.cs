using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public GameObject startGamePanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

    public Text score;
    public Text lifes;
    public Text hiScore;

    #region Singleton
    public static HudManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        startGamePanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        startGamePanel.SetActive(false);
        gamePanel.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }

    public void AttScore(float value)
    {
        score.text = $"Score: \n{value.ToString("0000")}";
    }

    public void AttLifes(int value)
    {
        lifes.text = $"Life: {value.ToString()}";
    }

    public void AttHiScore(float value) 
    {
        hiScore.text = $"Hi-Score: \n{value.ToString("0000")}";
    }
}
