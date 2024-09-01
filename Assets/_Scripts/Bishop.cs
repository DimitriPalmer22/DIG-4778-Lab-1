using UnityEngine;

public class Bishop : MonoBehaviour, IChessPiece
{
    private bool isCorrectTag = false;

    public void CheckTag()
    {
        if (gameObject.CompareTag("Bishop"))
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
            Gizmos.color = Color.yellow;
            Vector2 bishopPosition = transform.position;

            for (int i = 1; i <= 7; i++)
            {
                DrawLine2D(bishopPosition, bishopPosition + new Vector2(i, i)); // Diagonal up-right
                DrawLine2D(bishopPosition, bishopPosition + new Vector2(-i, i)); // Diagonal up-left
                DrawLine2D(bishopPosition, bishopPosition + new Vector2(i, -i)); // Diagonal down-right
                DrawLine2D(bishopPosition, bishopPosition + new Vector2(-i, -i)); // Diagonal down-left
            }
        }
    }

    // Helper method to draw lines in 2D
    private void DrawLine2D(Vector2 start, Vector2 end)
    {
        Gizmos.DrawLine(new Vector3(start.x, start.y, 0), new Vector3(end.x, end.y, 0));
    }
}