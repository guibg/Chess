using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour
{
    public bool verifyMove(Vector3 position, Vector3 startingPosition)
    {
        if (!(position.x >= 0 && position.y >= 0 && position.x <= 7 && position.y <= 7)) return false;
        int x = Mathf.Abs((int)(position.x - startingPosition.x));
        int y = Mathf.Abs((int)(position.y - startingPosition.y));
        if (x == y)
        {
            if ((position.x - startingPosition.x) > 0 && (position.y - startingPosition.y) > 0)
            {
                for (int i = 1; startingPosition.x + i < position.x; i++)
                {
                    if (Board.boardPieces[(int)startingPosition.x + i, (int)startingPosition.y + i] != null)
                    {
                        return false;
                    }
                }
            }
            else if ((position.x - startingPosition.x) > 0 && (position.y - startingPosition.y) < 0)
            {
                for (int i = 1; startingPosition.x + i < position.x; i++)
                {
                    if (Board.boardPieces[(int)startingPosition.x + i, (int)startingPosition.y - i] != null)
                    {
                        return false;
                    }
                }
            }
            else if ((position.x - startingPosition.x) < 0 && (position.y - startingPosition.y) > 0)
            {
                for (int i = 1; startingPosition.x - i > position.x; i++)
                {
                    if (Board.boardPieces[(int)startingPosition.x - i, (int)startingPosition.y + i] != null)
                    {
                        return false;
                    }
                }
            }
            else if ((position.x - startingPosition.x) < 0 && (position.y - startingPosition.y) < 0)
            {
                for (int i = 1; startingPosition.x - i > position.x; i++)
                {
                    if (Board.boardPieces[(int)startingPosition.x - i, (int)startingPosition.y - i] != null)
                    {
                        return false;
                    }
                }
            }
        }
        else
        {
            return false;
        }
        return true;
    }
}
