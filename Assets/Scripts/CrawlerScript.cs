using UnityEngine;

public class CrawlerScript : EnemyScript
{
    public float sight;
    public LayerMask playerLayer;
    public float normalMoveSpeed;
    public float newMoveSpeed;


    protected override void Start()
    {
        base.Start();
        normalMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        if (chargeDetection())
        {
            moveSpeed = newMoveSpeed;
        }
        else
        {
            moveSpeed = normalMoveSpeed;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }


        if (direction > 0)
        {
            sr.flipX = false;
        }


        if (direction < 0)
        {
            sr.flipX = true;
        }

    }

    private bool chargeDetection()
    {
        Vector2 dir = new Vector2(direction, 0);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, dir, sight, playerLayer);

        return hit;

    }







}

