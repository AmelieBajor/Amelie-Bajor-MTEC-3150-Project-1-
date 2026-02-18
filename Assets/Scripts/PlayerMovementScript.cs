using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;

    public LayerMask ground;

    public GameObject meleeAttack;
    public GameObject bulletPrefab;
    private float facingDirection;

    public float meleeDuration = 0.25f;
    private float timeElapsedSinceMelee = 0;

    private bool meleeTriggered;

    private float xMove;
    private bool jumpFlag = false;
    private float xVelocity;
    private Rigidbody2D rb;

    private float attackOffset = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingDirection = 1;


    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        xVelocity = xMove * movementSpeed * Time.deltaTime;

        //transform.Translate(xMove * movementSpeed * Time.deltaTime,0,0);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {

            jumpFlag = true;

        }

        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            RangedAttack();
        }

        if (meleeTriggered)
        {
            if (timeElapsedSinceMelee < meleeDuration)
            {
                timeElapsedSinceMelee += Time.deltaTime;

            }
            else
            {
                meleeAttack.SetActive(false);
                timeElapsedSinceMelee = 0;
                meleeTriggered = false;

            }

        }

        //Debug.Log(IsGrounded());
        if (xMove != 0)
        {

            facingDirection = xMove;

        }
    }


    private void FixedUpdate()
    {
        xVelocity = xMove * movementSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, 0);

        if (jumpFlag)
        {
            rb.linearVelocityY = jumpSpeed;
            jumpFlag = false;
        }

    }

    private void MeleeAttack()
    {
        meleeTriggered = true;
        meleeAttack.SetActive(true);
        meleeAttack.transform.localPosition = new Vector3(attackOffset * facingDirection, meleeAttack.transform.localPosition.y, 0);

    }

    private void RangedAttack()
    {
        Vector3 pos = new Vector3(transform.position.x + (attackOffset * facingDirection), transform.position.y, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        bullet.GetComponent<FireballScript>().direction = new Vector2(facingDirection, 0);


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUpScript>() != null)
        {
            collision.GetComponent<PowerUpScript>().ApplyEffect();

        }

    }

    private bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;

        return Physics2D.CircleCast(transform.position, radius, Vector2.down, dist, ground);

    }

}