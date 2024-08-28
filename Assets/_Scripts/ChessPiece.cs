using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class ChessPiece : MonoBehaviour
{
    public enum PieceType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }

    [SerializeField] private Color color;
    
    [SerializeField] private PieceType pieceType;

    [Header("Piece Types")]
    [SerializeField] private GameObject pawnn;
    [SerializeField] private GameObject rook;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject bishop;
    [SerializeField] private GameObject queen;
    [SerializeField] private GameObject king;

    private GameObject _piece;
    
    // Start is called before the first frame update
    void Start()
    {
        // Spawn a pawn if the piece is null
        if (_piece == null)
            InstantiatePiece(PieceType.Pawn);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the correct piece is instantiated
        if (_piece != null && _piece.tag != pieceType.ToString())
        {
            DestroyImmediate(_piece);
            InstantiatePiece(pieceType);
        }
        
        ApplyColor();
    }

    private void InstantiatePiece(PieceType pieceType)
    {
        switch (pieceType)
        {
            case PieceType.Pawn:
                _piece = Instantiate(pawnn, transform);
                break;
            case PieceType.Rook:
                _piece = Instantiate(rook, transform);
                break;
            case PieceType.Knight:
                _piece = Instantiate(knight, transform);
                break;
            case PieceType.Bishop:
                _piece = Instantiate(bishop, transform);
                break;
            case PieceType.Queen:
                _piece = Instantiate(queen, transform);
                break;
            case PieceType.King:
                _piece = Instantiate(king, transform);
                break;
        }
    }

    private void ApplyColor()
    {
        if (_piece == null)
            return;
        
        // Get the sprite renderer of the piece
        var spriteRenderer = _piece.GetComponent<SpriteRenderer>();
        
        if (spriteRenderer == null)
            return;
        
        // Set the color of the piece
        spriteRenderer.color = color;
    }
}