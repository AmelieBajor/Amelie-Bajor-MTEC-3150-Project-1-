using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float moveSpeed;
    public int hp;
    public float direction;
    protected Rigidbody2D rb;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {

        rb = GetComponent<Rigidbody2D>();


    }

    protected virtual void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed * Time.deltaTime, rb.linearVelocity.y);
    }
}
