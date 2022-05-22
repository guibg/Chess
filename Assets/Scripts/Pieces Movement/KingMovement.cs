using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovement : MonoBehaviour
{
    public bool verifyMove(Vector3 position, Vector3 startingPosition)
    {
        if (!(position.x >= 0 && position.y >= 0 && position.x <= 7 && position.y <= 7)) return false;
        int x = Mathf.Abs((int)(position.x - startingPosition.x));
        int y = Mathf.Abs((int)(position.y - startingPosition.y));
        if (x < 2 && y < 2)
        {
            return true;
        }
        return false;
    }
}
