// ===============================
// CustomCollider.cs
// ===============================
using UnityEngine;

// Tipos de colisi�n soportados por los objetos
public enum ColliderType { AABB, Circle, OBB }

// Script que define un collider personalizado
public class CustomCollider : MonoBehaviour
{
    public ColliderType type; // Tipo de colisi�n (seleccionado desde el Inspector)

    private void Start()
    {
        // Se registra este objeto en el gestor de colisiones al iniciar
        CollisionManager.Instance.Register(this);
    }

    // Cambia el color a rojo si est� colisionando
    public void OnCollision()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Restaura el color si no hay colisi�n
    public void OnNoCollision()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}


