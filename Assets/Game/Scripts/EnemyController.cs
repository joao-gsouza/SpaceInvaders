using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemies1List;
    public GameObject enemies2List;
    public GameObject enemies3List;

    EnemyMovement enemyMovement;

    bool canAddDificultyEnemy1 = true;
    bool canAddDificultyEnemy2 = true;
    bool canAddDificultyEnemy3 = true;

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void VerifyEnemies(GameObject enemy)
    {
        Debug.Log("Chamei verify");

        var enemies1 = enemies1List.GetComponentsInChildren<BoxCollider2D>().ToList().Select(x=> x.gameObject).ToList();
        var enemies2 = enemies2List.GetComponentsInChildren<BoxCollider2D>().ToList().Select(x => x.gameObject).ToList();
        var enemies3 = enemies3List.GetComponentsInChildren<BoxCollider2D>().ToList().Select(x => x.gameObject).ToList();

        if (enemy.CompareTag("Enemy1"))
        {
            enemies1.Remove(enemy);
        }else if (enemy.CompareTag("Enemy2"))
        {
            enemies2.Remove(enemy);
        }
        else if (enemy.CompareTag("Enemy3"))
        {
            enemies3.Remove(enemy);
        }

        var quantAddMaxDistance = (enemyMovement.quantAddMaxDistance / 1.5f);

        var enemiesMax = enemies1.FindAll(x => x.name == (11 - quantAddMaxDistance).ToString());
        enemiesMax.AddRange(enemies2.FindAll(x => x.name == (11 - quantAddMaxDistance).ToString()));
        enemiesMax.AddRange(enemies3.FindAll(x => x.name == (11 - quantAddMaxDistance).ToString()));

        if (enemiesMax.Count <= 0)
        {
            enemyMovement.quantAddMaxDistance += 1.5f;
        }

        var quantAddMinDistance = (enemyMovement.quantAddMinDistance / 1.5f);

        var enemiesMin = enemies1.FindAll(x => x.name == (1 + quantAddMinDistance).ToString());
        enemiesMin.AddRange(enemies2.FindAll(x =>  x.name == (1 + quantAddMinDistance).ToString()));
        enemiesMin.AddRange(enemies3.FindAll(x =>  x.name == (1 + quantAddMinDistance).ToString()));

        if (enemiesMin.Count <= 0)
        {
            enemyMovement.quantAddMinDistance += 1.5f;
        }

        var quantEnemies1Alive = enemies1.Count;
        var quantEnemies2Alive = enemies2.Count;
        var quantEnemies3Alive = enemies3.Count;

        int totalEnemiesAlive = quantEnemies1Alive + quantEnemies2Alive + quantEnemies3Alive;

        //if (canAddDificultyEnemy1 && quantEneimes1Alive <= 0)
        //{
        //    canAddDificultyEnemy1 = false;
        //    enemyMovement.timeToMove /= 2;
        //}

        //if (canAddDificultyEnemy2 && quantEneimes2Alive <= 0)
        //{
        //    canAddDificultyEnemy2 = false;
        //    enemyMovement.timeToMove /= 2;
        //}

        //if (canAddDificultyEnemy3 && quantEneimes3Alive <= 0)
        //{
        //    canAddDificultyEnemy3 = false;
        //    enemyMovement.timeToMove /= 2;
        //}

        if (canAddDificultyEnemy1 && totalEnemiesAlive <= 25)
        {
            canAddDificultyEnemy1 = false;
            enemyMovement.timeToMove /= 2;
        }

        if (canAddDificultyEnemy2 && totalEnemiesAlive <= 15)
        {
            canAddDificultyEnemy2 = false;
            enemyMovement.timeToMove /= 2;
        }

        if (canAddDificultyEnemy3 && totalEnemiesAlive <= 5)
        {
            canAddDificultyEnemy3 = false;
            enemyMovement.timeToMove /= 2;
        }


        if (quantEnemies1Alive <= 0 && quantEnemies2Alive <= 0 && quantEnemies3Alive <= 0)
        {
            SpawnManager.Instance.NextWave();
            Destroy(gameObject);
        }
    }
}
