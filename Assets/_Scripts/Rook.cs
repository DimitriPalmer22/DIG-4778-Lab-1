using UnityEngine;

public class Rook : MonoBehaviour, IChessPiece
{
    private bool isCorrectTag = false;

    public void CheckTag()
    {
        if (gameObject.CompareTag("Rook"))
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
            Gizmos.color = Color.red;
            Vector2 currentPosition = transform.position;

            for (int i = 1; i <= 7; i++)
            {
                DrawLine2D(currentPosition, currentPosition + new Vector2(i, 0)); // Horizontal
                DrawLine2D(currentPosition, currentPosition + new Vector2(-i, 0)); // Horizontal
                DrawLine2D(currentPosition, currentPosition + new Vector2(0, i)); // Vertical
                DrawLine2D(currentPosition, currentPosition + new Vector2(0, -i)); // Vertical
            }
        }
    }

    // Helper method to draw lines in 2D
    private void DrawLine2D(Vector2 start, Vector2 end)
    {
        Gizmos.DrawLine(new Vector3(start.x, start.y, 0), new Vector3(end.x, end.y, 0));
    }
}