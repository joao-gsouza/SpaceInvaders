using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int life;
    public SpriteRenderer sprite;

    public float maxLife;

    private void Start()
    {
        maxLife = life;
        SetColor();
    }

    public void OnDamage()
    {
        life--;

        SetColor();

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }


    void SetColor()
    {
        float t = 1f - (life / maxLife);
        Color newColor = Color.Lerp(Color.green, Color.orangeRed, t);

        sprite.color = newColor;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") || collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            OnDamage();
            return;
        }

        if (collision.CompareTag("Enemy1") || collision.CompareTag("Enemy2") || collision.CompareTag("Enemy3"))
        {
            Destroy(collision.gameObject);
            OnDamage();
            return;
        }
    }
}
