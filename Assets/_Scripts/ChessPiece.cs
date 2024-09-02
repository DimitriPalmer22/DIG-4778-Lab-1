using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(SpriteRenderer))]
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

    [SerializeField] private PieceType pieceType;
    [SerializeField] private Color color;

    [Header("Sprite List")]
    [SerializeField] private Sprite pawnSprite;
    [SerializeField] private Sprite rookSprite;
    [SerializeField] private Sprite knightSprite;
    [SerializeField] private Sprite bishopSprite;
    [SerializeField] private Sprite queenSprite;
    [SerializeField] private Sprite kingSprite;

    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the sprite renderer is null
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponent<SpriteRenderer>();

        ApplySprite();
        ApplyColor();
    }

    private void ApplyColor()
    {
        // Set the color of the piece
        _spriteRenderer.color = color;
    }

    private void ApplySprite()
    {
        
        // Set the sprite of the piece
        switch (pieceType)
        {
            case PieceType.Pawn:
                _spriteRenderer.sprite = pawnSprite;
                break;
         
            case PieceType.Rook:
                _spriteRenderer.sprite = rookSprite;
                break;
            
            case PieceType.Knight:
                _spriteRenderer.sprite = knightSprite;
                break;
            
            case PieceType.Bishop:
                _spriteRenderer.sprite = bishopSprite;
                break;
            
            case PieceType.Queen:
                _spriteRenderer.sprite = queenSprite;
                break;
            
            case PieceType.King:
                _spriteRenderer.sprite = kingSprite;
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}