using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    private bool hasMoved = false;
    public bool verifyMove(Vector3 position, Vector3 startingPosition)
    {
        if (!(position.x >= 0 && position.y >= 0 && position.x <= 7 && position.y <= 7)) return false;
        int x = Mathf.Abs((int)(position.x - startingPosition.x));
        int y = Mathf.Abs((int)(position.y - startingPosition.y));
        if (!(hasMoved) && x == 0 && y == 2)
        {
            if (!(Board.isWhiteTurn))
            {
                x *= -1;
                y *= -1;
            }
            if (Board.boardPieces[(int)startingPosition.x, (int)startingPosition.y + (y / 2)] == null && Board.boardPieces[(int)startingPosition.x, (int)(startingPosition.y + y)] == null)
            {
                hasMoved = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (x == 0 && y == 1 && Board.boardPieces[(int)startingPosition.x, (int)(startingPosition.y + y)] == null)
        {
            hasMoved = true;
            return true;
        }
        else if (x == 1 && y == 1 && Board.boardPieces[(int)position.x, (int)(position.y)] != null)
        {
            hasMoved = true;
            return true;
        }
        else
        {
            return false;
        }
    }


}
