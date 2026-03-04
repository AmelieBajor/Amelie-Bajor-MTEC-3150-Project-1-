using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;
    public float sprintingSpeed;
    public float walkingSpeed;
    public float health;
    public float maxHealth;
    public float IFramesTimer = 0;
    public float maxIFrames;
    public bool IFramesTrue = false;

    public LayerMask ground;

    public GameObject meleeAttack;
    public GameObject bulletPrefab;
    public GameObject invincibleShield;
    private float facingDirection;

    public float meleeDuration = 0.25f;
    private float timeElapsedSinceMelee = 0;

    public bool meleeTriggered;

    private float xMove;
    private bool jumpFlag = false;
    private float xVelocity;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private float attackOffset = 0.3f;

    private AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip powerupClip;
    public AudioClip attackClip;
    public AudioClip fireballClip;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        facingDirection = 1;


    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintingSpeed;
        }
        else
        {
            movementSpeed = walkingSpeed;
        }


        xVelocity = xMove * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            anim.SetTrigger("Jump");
            audioSource.PlayOneShot(jumpClip);
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

        if (health == 5)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(true);
        }

        if (health == 4)
        {
            health1.SetActive(false);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(true);
        }

        if (health == 3)
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(true);
        }

        if (health == 2)
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(true);
            health5.SetActive(true);
        }

        if (health == 1)
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(true);
        }

        if (health == 0)
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);
        }


        //Debug.Log(IsGrounded());
        if (xMove != 0)
        {

            facingDirection = xMove;
            anim.SetBool("isWalking", true);

        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (IFramesTrue == true)
        {
            if (IFramesTimer <= maxIFrames)
            {
                IFramesTimer += Time.deltaTime;
                invincibleShield.SetActive(true);
            }
            else
            {
                IFramesTrue = false;
                IFramesTimer = 0;
                invincibleShield.SetActive(false);
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (facingDirection > 0)
        {
            sr.flipX = false;
        }


        if (facingDirection < 0)
        {
            sr.flipX =true;
        }

    }


    private void FixedUpdate()
    {
        xVelocity = xMove * movementSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, 0);

        anim.SetFloat("yVelo", rb.linearVelocityY);

        if (jumpFlag)
        {
            rb.linearVelocityY = jumpSpeed;
            jumpFlag = false;
        }

    }

    private void MeleeAttack()
    {
        anim.SetTrigger("Attack");
        meleeTriggered = true;
        meleeAttack.SetActive(true);
        meleeAttack.transform.localPosition = new Vector3(0, meleeAttack.transform.localPosition.y, 0);
        audioSource.PlayOneShot(attackClip);

    }

    private void RangedAttack()
    {
        Vector3 pos = new Vector3(transform.position.x + (attackOffset * facingDirection), transform.position.y, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        bullet.GetComponent<FireballScript>().direction = new Vector2(facingDirection, 0);
        audioSource.PlayOneShot(fireballClip);


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUpScript>() != null)
        {
            audioSource.PlayOneShot(powerupClip);
            collision.GetComponent<PowerUpScript>().ApplyEffect();

        }

        if (collision.CompareTag("Enemy"))
        {

            health -= 1;
            Destroy(collision.gameObject);
        }



    }

    public void onLanding()
    {
        anim.SetTrigger("Landed");
    }


    private bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;
        onLanding();

        return Physics2D.CircleCast(transform.position, radius, Vector2.down, dist, ground);

    }
}
