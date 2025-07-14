using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy1"))
        {
            GameManager.Instance.AddScore(10);
            collision.GetComponent<Enemy>().Death();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag("Enemy2"))
        {
            GameManager.Instance.AddScore(20);
            collision.GetComponent<Enemy>().Death();
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag("Enemy3"))
        {
            GameManager.Instance.AddScore(50);
            collision.GetComponent<Enemy>().Death();
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            return;
        }
    }
}
