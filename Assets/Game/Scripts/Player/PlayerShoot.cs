using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bulletForce;
    public GameObject bullet;
    public Transform firePoint;
    public GameObject bulletParent;

    public float attackSpeed;

    float timer;
    bool canAttack;


    void FixedUpdate()
    {
        if (GameManager.Instance.GamePaused)
        {
            return;
        }

        if (!canAttack)
        {
            if (timer >= attackSpeed)
            {
                timer = 0;
                canAttack = true;
            }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }

        if (canAttack && Input.GetKey(KeyCode.Space))
        {
            canAttack = false;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity, bulletParent.transform);

        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletForce, ForceMode2D.Impulse);
    }
}
