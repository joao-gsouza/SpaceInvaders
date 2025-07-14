using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.GamePaused)
        {
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            rig.MovePosition(transform.position + new Vector3(horizontal, 0,0) * (speed / 10));
        }
    }
}
