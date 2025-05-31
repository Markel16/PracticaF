using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // Fuerza del salto hacia arriba
    public float forwardSpeed = 2f; // Velocidad constante hacia la derecha

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Referencia al Rigidbody2D
    }

    private void Update()
    {
        // Detectar si se pulsa espacio para saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Reinicia velocidad vertical
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplica impulso hacia arriba
        }
    }

    private void FixedUpdate()
    {
        // Mantiene velocidad horizontal constante hacia la derecha
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar si el objeto con el que colisionamos tiene CustomCollider
        CustomCollider custom = collision.gameObject.GetComponent<CustomCollider>();

        if (custom != null)
        {
            if (custom.type == ColliderType.AABB)
            {
                // Si es AABB (cuadrado), activamos Game Over
                GameManager.Instance.GameOver();
            }
            else
            {
                // Si es un círculo, no morimos, pero mostramos mensaje y pintamos el objeto de verde
                Debug.Log("Colisión con círculo: no muere");
                custom.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
        else
        {
            // Si no tiene CustomCollider, lo tratamos como obstáculo mortal
            GameManager.Instance.GameOver();
        }
    }
}