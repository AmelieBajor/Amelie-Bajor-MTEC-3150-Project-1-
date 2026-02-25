using UnityEngine;

public class CrawlerScript : EnemyScript
{
    public PlayerMovementScript player;




    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.health -= 1;
            Destroy(gameObject);

        }

            if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

    }

}
