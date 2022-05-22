using System;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private bool enableDrag = true;
    private bool isWhite;
    private Vector3 startingPosition = new Vector3();
    private string pieceType;
    private Collider2D pieceCollider;
    public void setPieceType(String pieceType)
    {
        this.pieceType = pieceType;
    }
    public void setIsWhite(String name)
    {
        if (name.ToLower().Contains("white"))
        {
            isWhite = true;
        }
        else
        {
            isWhite = false;
        }
    }
    private void Start()
    {
        pieceCollider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        enableDrag = true;
        startingPosition = new Vector3(transform.position.x, transform.position.y);
    }
    private void OnMouseDrag()
    {
        if (!enableDrag) return;
        if (Input.GetMouseButton(1))
        {
            enableDrag = false;
            transform.position = startingPosition;
            return;
        }
        if (GetMousePosition().x > -0.5 && GetMousePosition().x < 7.5)
        {
            transform.position = new Vector3(GetMousePosition().x, transform.position.y);
        }
        if (GetMousePosition().y > -0.5 && GetMousePosition().y < 7.5)
        {
            transform.position = new Vector3(transform.position.x, GetMousePosition().y);
        }
    }
    private void OnMouseUp()
    {
        verifySpace();
    }

    private void verifySpace()
    {
        int x = (int)Mathf.Round(transform.position.x);
        int y = (int)Mathf.Round(transform.position.y);
        Vector3 placePiecePosition = new Vector3(x, y);

        if (!(turnIsCorrect() && callVerifyMove(placePiecePosition)))
        {
            transform.position = startingPosition;
            return;
        }
        if (Board.boardPieces[x, y] == null)
        {
            invertTurn();
            placePiece(x, y);
            return;
        }
        if (Board.boardPieces[x, y].isWhite != Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y].isWhite)
        {
            invertTurn();
            Destroy(Board.boardPieces[x, y].gameObject);
            placePiece(x, y);
            return;
        }
        transform.position = startingPosition;
    }

    private bool callVerifyMove(Vector3 position)
    {
        if (pieceType.Equals("horse"))
        {
            HorseMovement horse = Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y].gameObject.GetComponent<HorseMovement>();
            return horse.verifyMove(position, startingPosition);
        }
        else if (pieceType.Equals("pawn"))
        {
            PawnMovement pawn = Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y].gameObject.GetComponent<PawnMovement>();
            return pawn.verifyMove(position, startingPosition);
        }
        else if (pieceType.Equals("king"))
        {
            KingMovement king = Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y].gameObject.GetComponent<KingMovement>();
            return king.verifyMove(position, startingPosition);
        }
        else if (pieceType.Equals("rook"))
        {
            RookMovement rook = Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y].gameObject.GetComponent<RookMovement>();
            return rook.verifyMove(position, startingPosition);
        }
        else if (pieceType.Equals("bishop"))
        {
            BishopMovement bishop = Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y].gameObject.GetComponent<BishopMovement>();
            return bishop.verifyMove(position, startingPosition);
        }
        else if (pieceType.Equals("queen"))
        {
            QueenMovement queen = Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y].gameObject.GetComponent<QueenMovement>();
            return queen.verifyMove(position, startingPosition);
        }
        return true;
    }

    private void placePiece(int x, int y)
    {
        Board.boardPieces[x, y] = Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y];
        Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y] = null;
        centerPieceOnTile(x, y);
        if(Board.boardPieces[x, y].pieceType.Equals("pawn")){
            transformToQueen(x,y);
        }

    }
    private void transformToQueen(int x, int y)
    {
        if(x==7 && Board.boardPieces[x, y].isWhite){
            //Board.boardPieces[x, y] = Board._whiteQueenPrefab;
            Board.boardPieces[x, y].pieceType = "queen";
        }else if(x==0 && !Board.boardPieces[x, y].isWhite){
            //Board.boardPieces[x, y] = Board._blackQueenPrefab;
            Board.boardPieces[x, y].pieceType = "queen";
        }
    }

    private void invertTurn()
    {
        Board.isWhiteTurn = !Board.isWhiteTurn;
    }

    public bool turnIsCorrect()
    {
        if (Board.isWhiteTurn == isWhite)
        {
            return true;
        }
        transform.position = startingPosition;
        return false;
    }

    private void centerPieceOnTile(int x, int y)
    {
        transform.position = new Vector3(x, y, 0);
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
