using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float bulletForce;
    public GameObject bullet;
    public Transform firePoint;
    public Vector2 timerToShootRange;
    public float chanceToShoot;

    float timer;
    float attackSpeed;

    private void Start()
    {
        attackSpeed = Random.Range(timerToShootRange.x, timerToShootRange.y);
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.GamePaused)
        {
            return;
        }

        if (timer >= attackSpeed)
        {
            timer = 0;

            if (chanceToShoot >= Random.Range(0,100f))
            {
                Shoot();
            }
        }
        else
        {
            timer += Time.fixedDeltaTime;
        }
    }


    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * bulletForce, ForceMode2D.Impulse);
    }
}
