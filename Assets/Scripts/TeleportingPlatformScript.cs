using UnityEngine;

public class TeleportingPlatformScript : MonoBehaviour
{
    protected SpriteRenderer sr;
    protected Rigidbody2D rb;
    public bool visible;
    public Color appearingColor;
    public Color tangibleColor;
    public float durationTimer;
    public float reappearingTimer;
    public int randomChance;
    public GameObject hitbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomChance = Random.Range(0, 2);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (randomChance == 0)
        {
            visible = true;
        }

        if (randomChance == 1)
        {
            visible = false;
        }


        if (visible)
        {
            Reappearing();
            durationTimer = 0;

            if (durationTimer < 10)
            {
                durationTimer += Time.deltaTime;
            }

            if (durationTimer > 10)
            {
                randomChance = Random.Range(0, 2);
                durationTimer = 0;
            }
        }



    }

    private void Reappearing()
    {
        reappearingTimer = 0;
        if (reappearingTimer < 3)
        {
            reappearingTimer += Time.deltaTime;

        }
        if (reappearingTimer > 3)
        {
            hitbox.SetActive(true);
        }


    }
}
