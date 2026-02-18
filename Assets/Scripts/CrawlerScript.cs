using UnityEngine;

public class CrawlerScript : EnemyScript
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

    }

}
