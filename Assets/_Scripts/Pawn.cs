using UnityEngine;

public class Pawn : MonoBehaviour, IChessPiece
{
    private bool isCorrectTag = false;

    public void CheckTag()
    {
        if (gameObject.CompareTag("Pawn"))
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
            Gizmos.color = Color.blue;
            DrawLine2D(transform.position, transform.position + Vector3.up); // Pawn moves forward
        }
    }

    // Helper method to draw lines in 2D
    private void DrawLine2D(Vector2 start, Vector2 end)
    {
        Gizmos.DrawLine(new Vector3(start.x, start.y, 0), new Vector3(end.x, end.y, 0));
    }
}