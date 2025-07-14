using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class EnemyMovement : MonoBehaviour
{
    public float timeToMove;
    public float timeToMoveDown;
    public float quantAddMaxDistance;
    public float quantAddMinDistance;

    int direction = 1;
    float timerToMove;
    float timerToMoveDown;
    float distanceMax = 0.8f;

    void FixedUpdate()
    {
        if (GameManager.Instance.GamePaused)
        {
            return;
        }

        if (timerToMoveDown >= timeToMoveDown)
        {
            timerToMoveDown = 0;

            MoveDown();
        }
        else
        {
            timerToMoveDown += Time.fixedDeltaTime;
        }


        if (timerToMove >= timeToMove)
        {
            timerToMove = 0;

            if (transform.position.x >= (distanceMax + quantAddMaxDistance) || transform.position.x <= -(distanceMax + quantAddMinDistance))
            {
                direction *= -1;
                MoveDown();
            }

            Move();
        }
        else
        {
            timerToMove += Time.fixedDeltaTime;
        }
    }

    void MoveDown()
    {
        transform.position -= new Vector3(0,0.5f,0);
    }

    void Move()
    {
        transform.position += new Vector3(0.1f * direction,0,0);
    }
}
