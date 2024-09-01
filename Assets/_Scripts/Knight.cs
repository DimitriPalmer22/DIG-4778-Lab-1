using UnityEngine;

public class Knight : MonoBehaviour, IChessPiece
{
    private bool isCorrectTag = false;

    public void CheckTag()
    {
        if (gameObject.CompareTag("Knight"))
        {
            isCorrectTag = true;
        }
        else
        {
            isCorrectTag = false;
        }
    }

    public void OnDrawGizmosSelected()
    {
        CheckTag();

        if (isCorrectTag)
        {
            Gizmos.color = Color.green;
            Vector2 knightPosition = transform.position;

            // Draw L-shaped moves for the Knight
            // Two squares in one direction and one square perpendicular
            DrawLine2D(knightPosition, knightPosition + new Vector2(2, 1));  // Move right two, up one
            DrawLine2D(knightPosition, knightPosition + new Vector2(2, -1)); // Move right two, down one
            DrawLine2D(knightPosition, knightPosition + new Vector2(-2, 1)); // Move left two, up one
            DrawLine2D(knightPosition, knightPosition + new Vector2(-2, -1));// Move left two, down one

            // One square in one direction and two squares perpendicular
            DrawLine2D(knightPosition, knightPosition + new Vector2(1, 2));  // Move up two, right one
            DrawLine2D(knightPosition, knightPosition + new Vector2(-1, 2)); // Move up two, left one
            DrawLine2D(knightPosition, knightPosition + new Vector2(1, -2)); // Move down two, right one
            DrawLine2D(knightPosition, knightPosition + new Vector2(-1, -2));// Move down two, left one
        }
    }

    // Helper method to draw lines in 2D
    private void DrawLine2D(Vector2 start, Vector2 end)
    {
        Gizmos.DrawLine(new Vector3(start.x, start.y, 0), new Vector3(end.x, end.y, 0));
    }
}