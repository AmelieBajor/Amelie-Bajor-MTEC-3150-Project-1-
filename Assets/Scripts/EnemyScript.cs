using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    public int hp;
    public float direction;
    protected Rigidbody2D rb;
    public int bulletDamage = 1;
    public int meleeDamage = 3;
    public PlayerMovementScript player;
    public SpriteRenderer sr;
    public Animator anim;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }


    protected virtual void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed * Time.deltaTime, rb.linearVelocity.y);



    }






    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(player.meleeTriggered == false)
            {
                if (player.IFramesTrue == false)
                {
                    player.health--;
                    player.IFramesTrue = true;
                }

            }

            Destroy(gameObject);


        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }


        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            hp -= bulletDamage;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("PlayerMelee"))
        {
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("Void"))
        {
            Destroy(gameObject);

        }


    }




}
