using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnRate = 5;
    public float spawnTimer = 5;

    public float spawnerSpeed;
    private int direction = 1;
    private float directionDuration;
    public float maxDirectionDuration;
    public EnemyScript enemySpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = spawnRate;
    }

    private void Update()
    {
        if(enemySpawn.spawn == true)
        {
            if (spawnTimer < spawnRate)
            {
                spawnTimer += Time.deltaTime;
            }
            else
            {
                SpawnEnemy();
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



    // Update is called once per frame


    public void SpawnEnemy()
    {
        GameObject enemyPrefab = Instantiate(Enemy, transform.position, Quaternion.identity);
        EnemyScript enemyComponents = enemyPrefab.GetComponent<EnemyScript>();

        float rng = Random.value;
        enemyComponents.direction = Random.value > 0.5f ? 1 : -1;

    }
}
