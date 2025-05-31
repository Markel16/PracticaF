// ===============================
// CollisionFunctions.cs
// ===============================
using System.Collections.Generic;
using UnityEngine;

// Clase estática con funciones matemáticas para detección personalizada de colisiones
public static class CollisionFunctions
{
    // Detección de colisión entre un punto y un cuadrado AABB (Axis-Aligned Bounding Box)
    public static bool PointToAABB(Vector2 point, Vector2 center, Vector2 size)
    {
        float left = center.x - size.x / 2f;
        float right = center.x + size.x / 2f;
        float bottom = center.y - size.y / 2f;
        float top = center.y + size.y / 2f;

        return (point.x >= left && point.x <= right && point.y >= bottom && point.y <= top);
    }

    // Detección de colisión entre un punto y un círculo
    public static bool PointToCircle(Vector2 point, Vector2 center, float radius)
    {
        float distance = Vector2.Distance(point, center);
        return distance <= radius;
    }

    // Detección de colisión entre un círculo y un cuadrado AABB
    public static bool CircleToAABB(Vector2 circleCenter, float radius, Vector2 aabbCenter, Vector2 aabbSize)
    {
        float left = aabbCenter.x - aabbSize.x / 2f;
        float right = aabbCenter.x + aabbSize.x / 2f;
        float bottom = aabbCenter.y - aabbSize.y / 2f;
        float top = aabbCenter.y + aabbSize.y / 2f;

        float closestX = Mathf.Clamp(circleCenter.x, left, right);
        float closestY = Mathf.Clamp(circleCenter.y, bottom, top);

        float distance = Vector2.Distance(circleCenter, new Vector2(closestX, closestY));
        return distance <= radius;
    }

    // Detección de colisión entre dos cuadrados AABB
    public static bool AABBToAABB(Vector2 centerA, Vector2 sizeA, Vector2 centerB, Vector2 sizeB)
    {
        float leftA = centerA.x - sizeA.x / 2f;
        float rightA = centerA.x + sizeA.x / 2f;
        float bottomA = centerA.y - sizeA.y / 2f;
        float topA = centerA.y + sizeA.y / 2f;

        float leftB = centerB.x - sizeB.x / 2f;
        float rightB = centerB.x + sizeB.x / 2f;
        float bottomB = centerB.y - sizeB.y / 2f;
        float topB = centerB.y + sizeB.y / 2f;

        bool overlapX = rightA >= leftB && leftA <= rightB;
        bool overlapY = topA >= bottomB && bottomA <= topB;

        return overlapX && overlapY;
    }
}


