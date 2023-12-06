using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // Normaliza para asegurar que la velocidad diagonal no sea mayor

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jugador colisiona con un objeto, detén su movimiento
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}
