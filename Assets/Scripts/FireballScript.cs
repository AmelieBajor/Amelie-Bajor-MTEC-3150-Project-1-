using UnityEngine;

public class FireballScript : MonoBehaviour
{

    public float speed = 50;
    public Vector2 direction;
    private Rigidbody2D rb;
    private float despawnTimer;
    private float despawnLimit = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;

        if (despawnTimer < despawnLimit)
        {
            despawnTimer += Time.deltaTime;

        }
        else
        {
            despawnTimer = 0;
            Destroy(gameObject);
        }

        

    }
}