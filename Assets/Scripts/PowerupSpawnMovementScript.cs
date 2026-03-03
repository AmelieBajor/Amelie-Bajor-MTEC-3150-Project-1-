using UnityEngine;

public class PowerupSpawnMovementScript : MonoBehaviour
{

    public GameObject PowerUpPrefab;
    public float spawnTimer = 0;
    public float maxSpawnTime = 10;

    public float spawnerSpeed;
    private int direction = 1;
    private float directionDuration;
    public float maxDirectionDuration;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < maxSpawnTime)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(PowerUpPrefab, pos, Quaternion.identity);
            spawnTimer = 0;
        }

        if (directionDuration < maxDirectionDuration)
        {
            directionDuration += Time.deltaTime;

        }
        else
        {
            direction *= -1;
            directionDuration = 0;
        }

        transform.Translate(spawnerSpeed * direction * Time.deltaTime, 0, 0);


    }
}

