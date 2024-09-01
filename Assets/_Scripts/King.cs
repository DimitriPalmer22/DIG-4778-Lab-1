using UnityEngine;

public class King : MonoBehaviour, IChessPiece
{
    private bool isCorrectTag = false;

    public void CheckTag()
    {
        if (gameObject.CompareTag("King"))
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
            Gizmos.color = Color.cyan;
            Vector2 kingPosition = transform.position;
            DrawLine2D(kingPosition, kingPosition + new Vector2(1, 0)); // One step right
            DrawLine2D(kingPosition, kingPosition + new Vector2(-1, 0)); // One step left
            DrawLine2D(kingPosition, kingPosition + new Vector2(0, 1)); // One step up
            DrawLine2D(kingPosition, kingPosition + new Vector2(0, -1)); // One step down
            DrawLine2D(kingPosition, kingPosition + new Vector2(1, 1)); // Diagonal up-right
            DrawLine2D(kingPosition, kingPosition + new Vector2(-1, 1)); // Diagonal up-left
            DrawLine2D(kingPosition, kingPosition + new Vector2(1, -1)); // Diagonal down-right
            DrawLine2D(kingPosition, kingPosition + new Vector2(-1, -1)); // Diagonal down-left
        }
    }

    // Helper method to draw lines in 2D
    private void DrawLine2D(Vector2 start, Vector2 end)
    {
        Gizmos.DrawLine(new Vector3(start.x, start.y, 0), new Vector3(end.x, end.y, 0));
    }
}