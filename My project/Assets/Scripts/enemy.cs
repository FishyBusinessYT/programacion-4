using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed;
    public GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        manager = FindAnyObjectByType<GameManager>();

        Vector3 direction = Vector3.zero - transform.position;
        rigidBody.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rotation = -Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player(Clone)")
        {
            Destroy(coll.gameObject);
        }
    }

    void OnDestroy()
    {
        manager.EnemyKilled();
    }
}
