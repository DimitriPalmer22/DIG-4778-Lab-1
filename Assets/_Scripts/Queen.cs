using UnityEngine;

public class Queen : MonoBehaviour, IChessPiece
{
    private bool isCorrectTag = false;

    public void CheckTag()
    {
        if (gameObject.CompareTag("Queen"))
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
            Gizmos.color = Color.magenta;
            Vector2 queenPosition = transform.position;

            for (int i = 1; i <= 7; i++)
            {
                // Combine Rook and Bishop moves
                DrawLine2D(queenPosition, queenPosition + new Vector2(i, 0)); // Horizontal
                DrawLine2D(queenPosition, queenPosition + new Vector2(-i, 0)); // Horizontal
                DrawLine2D(queenPosition, queenPosition + new Vector2(0, i)); // Vertical
                DrawLine2D(queenPosition, queenPosition + new Vector2(0, -i)); // Vertical

                DrawLine2D(queenPosition, queenPosition + new Vector2(i, i)); // Diagonal up-right
                DrawLine2D(queenPosition, queenPosition + new Vector2(-i, i)); // Diagonal up-left
                DrawLine2D(queenPosition, queenPosition + new Vector2(i, -i)); // Diagonal down-right
                DrawLine2D(queenPosition, queenPosition + new Vector2(-i, -i)); // Diagonal down-left
            }
        }
    }

    // Helper method to draw lines in 2D
    private void DrawLine2D(Vector2 start, Vector2 end)
    {
        Gizmos.DrawLine(new Vector3(start.x, start.y, 0), new Vector3(end.x, end.y, 0));
    }
}