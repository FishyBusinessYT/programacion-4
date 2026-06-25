using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    private Vector3 mousePos;
    private float timer;
    private bool canFire = false;
    public GameManager manager;
    public GameObject bullet;
    public Transform bulletTransform;
    public float shotDelay;

    public AudioSource source;
    public AudioClip clip;
    public Volume volume;

    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
    }
    void Update()
    {
        float mouseX = Mouse.current.position.x.ReadValue();
        float mouseY = Mouse.current.position.y.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));

        Vector3 direction = mousePos - transform.position;
        float rotation = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotation);

        timer += Time.deltaTime;
        if (timer > shotDelay && !canFire) { canFire = true; }

        if (Mouse.current.leftButton.isPressed == true && canFire )
        {
            canFire = false;
            timer = 0;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            source.PlayOneShot(clip, volume.volume);
        }
    }
    void OnDestroy()
    {
        manager.PlayerKilled();
    }
}
