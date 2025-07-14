using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemies;

    float timer;
    bool startTimer;
    public int dificulty;

    #region Singleton
    public static SpawnManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        SpawnEnemies();
    }

    void FixedUpdate()
    {
        if (startTimer)
        {
            if (timer >= 1)
            {
                startTimer = false;
                timer = 0;
                GameManager.Instance.ResetMap();
                SpawnEnemies();
            }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }
    }

    public void NextWave()
    {
        startTimer = true;
    }

    public void SpawnEnemies()
    {
        var newEnemies = Instantiate(enemies);

        EnemyMovement enemyMovement = newEnemies.GetComponent<EnemyMovement>();

        enemyMovement.timeToMove -= enemyMovement.timeToMove * (dificulty / 10f);

        dificulty += 2;

        if (enemyMovement.timeToMove <= 0)
        {
            enemyMovement.timeToMove = 0.1f;
        }
    }
}
