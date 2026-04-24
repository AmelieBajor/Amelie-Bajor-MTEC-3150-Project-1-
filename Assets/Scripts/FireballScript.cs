using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float speed = 500;
    [HideInInspector] public Vector2 direction;
    private Rigidbody2D rb;

    public float despawnTimer;
    public float maxDespawnTime = 1;

    public int damageAmount = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        despawnTimer = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;

        if (despawnTimer <= maxDespawnTime)
        {
            despawnTimer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);

        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
