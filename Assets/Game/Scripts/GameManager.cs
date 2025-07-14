using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GamePaused;
    public GameObject obstacle;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject bulletPlayerParent;
    public GameObject bulletEnemiesParent;

    [SerializeField]
    private float score = 0;
    [SerializeField]
    int lifes = 3;
    [SerializeField]
    float hiScore = 0;

    #region Singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        GamePaused = true;

        if (PlayerPrefs.HasKey("HiScore"))
        {
            hiScore = PlayerPrefs.GetFloat("HiScore");
        }

        HudManager.Instance.AttLifes(lifes);
        HudManager.Instance.AttScore(score);
        HudManager.Instance.AttHiScore(hiScore);

        ResetMap();
    }

    public void AddScore(float value)
    {
        score += value;
        HudManager.Instance.AttScore(score);
    }

    public float GetScore()
    {
        return score;
    }

    public void OnDamage()
    {
        lifes--;
        HudManager.Instance.AttLifes(lifes);

        if (lifes <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GamePaused = true;

        if (score > hiScore)
        {
            PlayerPrefs.SetFloat("HiScore", score);
        }

        HudManager.Instance.GameOver();
    }

    public void StartGame()
    {
        GamePaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ResetMap()
    {
        Destroy(obstacle1);
        Destroy(obstacle2);
        Destroy(obstacle3);

        obstacle1 = Instantiate(obstacle,new Vector3(-5,-2.5f,0), Quaternion.identity);

        obstacle2 = Instantiate(obstacle, new Vector3(0, -2.5f, 0), Quaternion.identity);

        obstacle3 = Instantiate(obstacle, new Vector3(5, -2.5f, 0), Quaternion.identity);

        var bulletPlayer = bulletPlayerParent.GetComponentsInChildren<PlayerBullet>().Select(x => x.gameObject).ToList();

        foreach (var bullet in bulletPlayer)
        {
            Destroy(bullet);
        }

        var bulletEnemy = GameObject.FindGameObjectsWithTag("EnemyBullet");

        foreach (var bullet in bulletEnemy)
        {
            Destroy(bullet);
        }
    }
}
