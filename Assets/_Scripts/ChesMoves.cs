using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChesMoves : MonoBehaviour, IChessPiece
{
    private string pieceType = "Unknown"; // To store the type of the piece

    // Method to check for each piece type
    public void CheckTag()
    {
        // Check for each possible piece tag
        if (gameObject.CompareTag("Pawn"))
        {
            pieceType = "Pawn";
        }
        else if (gameObject.CompareTag("Rook"))
        {
            pieceType = "Rook";
        }
        else if (gameObject.CompareTag("Knight"))
        {
            pieceType = "Knight";
        }
        else if (gameObject.CompareTag("Bishop"))
        {
            pieceType = "Bishop";
        }
        else if (gameObject.CompareTag("Queen"))
        {
            pieceType = "Queen";
        }
        else if (gameObject.CompareTag("King"))
        {
            pieceType = "King";
        }
        else
        {
            pieceType = "Unknown";
        }
    }

    // Draw Gizmos based on the result of the tag check
    public void OnDrawGizmosSelected()
    {
        // Perform the tag check
        CheckTag();

        // Draw appropriate Gizmos based on the piece type
        switch (pieceType)
        {
            case "Pawn":
                Gizmos.color = Color.blue;
                DrawLine2D(transform.position, transform.position + Vector3.up); // Pawn moves forward
                break;

            case "Rook":
                Gizmos.color = Color.red;
                Vector2 currentPosition = transform.position;
                for (int i = 1; i <= 7; i++)
                {
                    DrawLine2D(currentPosition, currentPosition + new Vector2(i, 0)); // Horizontal
                    DrawLine2D(currentPosition, currentPosition + new Vector2(-i, 0)); // Horizontal
                    DrawLine2D(currentPosition, currentPosition + new Vector2(0, i)); // Vertical
                    DrawLine2D(currentPosition, currentPosition + new Vector2(0, -i)); // Vertical
                }
                break;

            case "Knight":
                Gizmos.color = Color.green;
                DrawLine2D(transform.position, transform.position + new Vector3(1, 2, 0)); // Example Knight move
                DrawLine2D(transform.position, transform.position + new Vector3(-1, 2, 0));
                DrawLine2D(transform.position, transform.position + new Vector3(1, -2, 0));
                DrawLine2D(transform.position, transform.position + new Vector3(-1, -2, 0));
                break;

            case "Bishop":
                Gizmos.color = Color.yellow;
                Vector2 bishopPosition = transform.position;
                for (int i = 1; i <= 7; i++)
                {
                    DrawLine2D(bishopPosition, bishopPosition + new Vector2(i, i)); // Diagonal up-right
                    DrawLine2D(bishopPosition, bishopPosition + new Vector2(-i, i)); // Diagonal up-left
                    DrawLine2D(bishopPosition, bishopPosition + new Vector2(i, -i)); // Diagonal down-right
                    DrawLine2D(bishopPosition, bishopPosition + new Vector2(-i, -i)); // Diagonal down-left
                }
                break;

            case "Queen":
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
                break;

            case "King":
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
                break;

            default:
                Gizmos.color = Color.gray;
                DrawLine2D(transform.position, transform.position + Vector3.up); // Draw a gray line if the type is unknown
                break;
        }
    }

    // Helper method to draw a line in 2D by converting Vector2 to Vector3
    private void DrawLine2D(Vector2 start, Vector2 end)
    {
        Gizmos.DrawLine(new Vector3(start.x, start.y, 0), new Vector3(end.x, end.y, 0));
    }
}
