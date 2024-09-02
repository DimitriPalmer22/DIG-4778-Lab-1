using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardGizmos : MonoBehaviour
{
    [SerializeField] private float cellSize = 1f;


    private void OnDrawGizmos()
    {
        // The number of cells in the chess board
        const int chessBoardSize = 8;

        Gizmos.color = Color.red;

        var startPosition = transform.position;

        // How far off the board to draw the lines
        const int overFlowAmount = 0;

        // Draw the lines for the chess board
        for (var i = -chessBoardSize / 2; i <= chessBoardSize / 2; i++)
        {
            var drawX = startPosition.x + i * cellSize;
            var drawY = startPosition.y - (chessBoardSize + overFlowAmount) / 2 * cellSize;

            var fromVector = new Vector2(drawX, drawY);
            var toVector = fromVector + new Vector2(0, cellSize * chessBoardSize + overFlowAmount);

            Gizmos.DrawLine(fromVector, toVector);
        }

        // Draw the lines for the chess board
        for (var i = -chessBoardSize / 2; i <= chessBoardSize / 2; i++)
        {
            var drawX = startPosition.x - (chessBoardSize + overFlowAmount) / 2 * cellSize;
            var drawY = startPosition.y - i * cellSize;

            var fromVector = new Vector2(drawX, drawY);
            var toVector = fromVector + new Vector2(cellSize * chessBoardSize + overFlowAmount, 0);

            Gizmos.DrawLine(fromVector, toVector);
        }
    }
}