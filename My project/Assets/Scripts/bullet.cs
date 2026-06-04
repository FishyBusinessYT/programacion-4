using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Rigidbody2D rigidBody;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3);

        rigidBody = GetComponent<Rigidbody2D>();

        float mouseX = Mouse.current.position.x.ReadValue();
        float mouseY = Mouse.current.position.y.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));

        Vector3 direction = mousePos - transform.position;
        
        rigidBody.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);
        Destroy(gameObject);
    }
}
