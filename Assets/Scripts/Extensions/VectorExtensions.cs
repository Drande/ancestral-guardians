using UnityEngine;

public static class VectorExtensions
{
    /// <summary>
    /// Converts a given 2D direction vector to a corresponding rotation angle in degrees.
    /// The angle is normalized to a value within the range [0, 360) and rounded to the nearest 90 degrees.
    /// </summary>
    /// <param name="direction">The input 2D direction vector.</param>
    /// <returns>A float representing the angle in degrees (0, 90, 180, 270, 360).</returns>
    public static float ToRotationAngle(this Vector2 direction)
    {
        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Normalize the angle to be in the range [0, 360)
        angle = (angle + 360) % 360;

        // Round the angle to the nearest 90 degrees
        angle = Mathf.Round(angle / 90) * 90;

        return angle;
    }

    /// <summary>
    /// Determines the last single-axis direction based on the current direction (which may be diagonal)
    /// and the previous direction. This method helps in reducing an 8-directional movement (including diagonals)
    /// to a single-axis direction (up, down, left, right).
    /// </summary>
    /// <param name="lastDirection">The current direction vector, potentially diagonal.</param>
    /// <param name="previousDirection">The previous direction vector.</param>
    /// <returns>A Vector2 representing the last single-axis direction (either on x-axis or y-axis).</returns>
    public static Vector2 GetLastAxisDirection(this Vector2 lastDirection, Vector2 previousDirection)
    {
        // If the last direction is already single-axis (magnitude 1), return it
        if (lastDirection.magnitude == 1) return lastDirection;

        // Subtract the previous direction from the last direction and round to the nearest integer values
        Vector2 finalDirection = new(
            Mathf.RoundToInt(lastDirection.x - previousDirection.x), 
            Mathf.RoundToInt(lastDirection.y - previousDirection.y)
        );

        return finalDirection;
    }

    public static Vector2 CalculateFourSideDirection(this Vector2 currentPosition, Vector2 targetPosition)
    {
        var difference = targetPosition - currentPosition;

        // Normalize the difference to get a unit vector pointing toward the target
        var normalizedDirection = difference.normalized;

        // Determine the closest cardinal direction
        if (Mathf.Abs(normalizedDirection.x) > Mathf.Abs(normalizedDirection.y))
        {
            // The object should move horizontally
            return new Vector2(Mathf.Sign(normalizedDirection.x), 0);
        }
        else
        {
            // The object should move vertically
            return new Vector2(0, Mathf.Sign(normalizedDirection.y));
        }
    }
}
