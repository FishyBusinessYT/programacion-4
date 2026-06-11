using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;
    public float spawnDelay;
    public float spawnRadius;
    public bool spawning = false;
    public GameObject enemy;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnDelay & spawning) {
            timer = 0;
            spawnDelay *= 0.99f;
            float rand = Random.value;

            float x = spawnRadius * Mathf.Cos(2 * Mathf.PI * rand);
            float y = spawnRadius * Mathf.Sin(2 * Mathf.PI * rand);

            Vector2 enemyPosition = new Vector2(x, y);
            Instantiate(enemy, enemyPosition, Quaternion.identity);
        }

    }
}
