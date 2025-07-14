using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Death()
    {
        var enemyController = GetComponentInParent<EnemyController>();

        enemyController.VerifyEnemies(gameObject);

        Destroy(gameObject);
    }
}
