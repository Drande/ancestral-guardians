using UnityEngine;

public static class TransformExtensions
{
    /// <summary>
    /// Rotates the transform to face towards the target Transform in 2D space.
    /// </summary>
    /// <param name="transform">The transform that will rotate to look at the target.</param>
    /// <param name="target">The target transform to look at.</param>
    public static void LookAt2D(this Transform transform, Transform target)
    {
        if (target == null) return;

        // Calculate the direction to the target
        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        // Calculate the angle and apply rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Rotates the transform to face towards the target Transform in 2D space, snapping the rotation to the nearest 90 degrees.
    /// </summary>
    /// <param name="transform">The transform that will rotate to look at the target.</param>
    /// <param name="target">The target transform to look at.</param>
    public static void LookAt2DSnapped(this Transform transform, Transform target)
    {
        if (target == null) return;

        // Calculate the direction to the target
        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Snap the angle to the nearest 90-degree increment
        float snappedAngle = Mathf.Round(angle / 90) * 90;

        // Apply the snapped rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, snappedAngle));
    }
}
