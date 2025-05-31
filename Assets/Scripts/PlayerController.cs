using UnityEngine;

// Este script controla al jugador (pájaro) en un juego tipo Flappy Bird
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;         // Fuerza del salto (impulso hacia arriba)
    public float forwardSpeed = 2f;      // Velocidad constante hacia la derecha

    private Rigidbody2D rb;              // Referencia al Rigidbody2D del jugador

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Se obtiene el Rigidbody2D al iniciar
    }

    private void Update()
    {
        // Detecta si se pulsa la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Reinicia la velocidad vertical para hacer saltos consistentes
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplica un impulso hacia arriba
        }
    }

    private void FixedUpdate()
    {
        // En cada frame de física, se mantiene el movimiento horizontal constante
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con algo (como una tubería u obstáculo), se activa el Game Over
        GameManager.Instance.GameOver();
    }
}
