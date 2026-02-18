using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    protected SpriteRenderer sr;
    public Color powerUpColor;
    public PlayerMovementScript player;
    private bool effectsApplied = false;
    public float effectDuration;
    public float timeElapsedSinceEffect;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = powerUpColor;

    }

    public virtual void ApplyEffect()
    {
        //player = GameObject.Find("Player").GetComponent<PlayerController>();
        //Destroy(gameObject);

        sr.enabled = false;
        effectsApplied = true;

    }


    private void Update()
    {
        if (effectsApplied)
        {
            if (timeElapsedSinceEffect < effectDuration)
            {
                timeElapsedSinceEffect += Time.deltaTime;
            }
            else
            {
                timeElapsedSinceEffect = 0;
                NegateEffect();
                effectsApplied = false;
                Destroy(gameObject);
            }

        }

    }
    protected virtual void NegateEffect()
    {


    }
}