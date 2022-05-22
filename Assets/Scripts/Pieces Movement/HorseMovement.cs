using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public bool verifyMove(Vector3 position, Vector3 startingPosition)
    {
        if (!(position.x >= 0 && position.y >= 0 && position.x <= 7 && position.y <= 7)) return false;
        int x = Mathf.Abs((int)(position.x - startingPosition.x));
        int y = Mathf.Abs((int)(position.y - startingPosition.y));
        if (x > 0 && y > 0 && x + y == 3)
        {
            return true;
        }
        return false;
    }

}
