// ===============================
// CollisionManager.cs
// ===============================
using System.Collections.Generic;
using UnityEngine;

// Script que gestiona las colisiones entre todos los objetos registrados
public class CollisionManager : MonoBehaviour
{
    public static CollisionManager Instance; // Singleton global
    private List<CustomCollider> colliders = new List<CustomCollider>(); // Lista de colliders registrados

    private void Awake()
    {
        if (Instance == null) Instance = this; // Asegura una sola instancia
    }

    // Añade un collider a la lista si no estaba ya
    public void Register(CustomCollider col)
    {
        if (!colliders.Contains(col))
            colliders.Add(col);
    }

    // En cada frame, comprueba todas las colisiones
    private void Update()
    {
        // Restablece el color de todos los objetos
        foreach (var col in colliders)
            col.OnNoCollision();

        // Compara todos los pares de objetos
        for (int i = 0; i < colliders.Count; i++)
        {
            for (int j = i + 1; j < colliders.Count; j++)
            {
                var a = colliders[i];
                var b = colliders[j];

                bool collided = false;

                // Detección según tipo de colisión entre Circle y AABB
                if (a.type == ColliderType.Circle && b.type == ColliderType.AABB)
                {
                    collided = CollisionFunctions.CircleToAABB(
                        a.transform.position,
                        a.GetComponent<SpriteRenderer>().bounds.size.x / 2f,
                        b.transform.position,
                        b.GetComponent<SpriteRenderer>().bounds.size
                    );
                }
                else if (a.type == ColliderType.AABB && b.type == ColliderType.Circle)
                {
                    collided = CollisionFunctions.CircleToAABB(
                        b.transform.position,
                        b.GetComponent<SpriteRenderer>().bounds.size.x / 2f,
                        a.transform.position,
                        a.GetComponent<SpriteRenderer>().bounds.size
                    );
                }
                // Detección entre dos AABB
                else if (a.type == ColliderType.AABB && b.type == ColliderType.AABB)
                {
                    collided = CollisionFunctions.AABBToAABB(
                        a.transform.position,
                        a.GetComponent<SpriteRenderer>().bounds.size,
                        b.transform.position,
                        b.GetComponent<SpriteRenderer>().bounds.size
                    );
                }

                // Si hay colisión, se marcan en rojo
                if (collided)
                {
                    a.OnCollision();
                    b.OnCollision();
                }
            }
        }
    }
}
