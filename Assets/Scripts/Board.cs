using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : Singleton<Board>
{
    [SerializeField] public Piece _whiteBishopPrefab;
    [SerializeField] public Piece _whiteHorsePrefab;
    [SerializeField] public Piece _whiteKingPrefab;
    [SerializeField] public Piece _whitePawnPrefab;
    [SerializeField] public Piece _whiteQueenPrefab;
    [SerializeField] public Piece _whiteRookPrefab;
    [SerializeField] public Piece _blackBishopPrefab;
    [SerializeField] public Piece _blackHorsePrefab;
    [SerializeField] public Piece _blackKingPrefab;
    [SerializeField] public Piece _blackPawnPrefab;
    [SerializeField] public Piece _blackQueenPrefab;
    [SerializeField] public Piece _blackRookPrefab;
    [SerializeField] private GameObject board;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform cameraT;
    public static Piece[,] boardPieces = new Piece[8, 8];
    public static bool isWhiteTurn = true;

    private bool _color;
    void Start()
    {
        createBoard();
        placeStartingPieces();
    }

    private void placeStartingPieces()
    {
        spawnPiece(_whiteQueenPrefab, new Vector3(3, 0), "WhiteQueen");
        spawnPiece(_blackQueenPrefab, new Vector3(3, 7), "BlackQueen");
        spawnPiece(_whiteKingPrefab, new Vector3(4, 0), "WhiteKing");
        spawnPiece(_blackKingPrefab, new Vector3(4, 7), "BlackKing");
        for (int i = 0; i < 8; i++)
        {
            spawnPiece(_whitePawnPrefab, new Vector3(i, 1), "WhitePawn");
            spawnPiece(_blackPawnPrefab, new Vector3(i, 6), "BlackPawn");
            if (i == 0 || i == 7)
            {
                spawnPiece(_whiteRookPrefab, new Vector3(i, 0), "WhiteRook");
                spawnPiece(_blackRookPrefab, new Vector3(i, 7), "BlackRook");
            }
            else if (i == 1 || i == 6)
            {
                spawnPiece(_whiteHorsePrefab, new Vector3(i, 0), "WhiteHorse");
                spawnPiece(_blackHorsePrefab, new Vector3(i, 7), "BlackHorse");
            }
            else if (i == 2 || i == 5)
            {
                spawnPiece(_whiteBishopPrefab, new Vector3(i, 0), "WhiteBishop");
                spawnPiece(_blackBishopPrefab, new Vector3(i, 7), "BlackBishop");
            }
        }
    }
    private void spawnPiece(Piece piece, Vector3 position, String name)
    {
        Piece spawnedPiece = Instantiate(piece, position, Quaternion.identity);
        spawnedPiece.name = piece.name;
        spawnedPiece.setIsWhite(piece.name);
        string pieceType = spawnedPiece.name.Replace("White_","").Replace("Black_","").ToLower();
        spawnedPiece.setPieceType(pieceType);
        boardPieces[(int)position.x, (int)position.y] = spawnedPiece;
    }

    void createBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                _color = false;
                Tile spawnedTile = Instantiate(_tilePrefab, new Vector3(i, j), Quaternion.identity);
                spawnedTile.name = $"Tile {i},{j}";
                if ((i + j) % 2 == 0) _color = true;
                spawnedTile.init(_color);
            }
        }
        cameraT.transform.position = new Vector3(3.5f, 3.5f, -10f);
    }

}
