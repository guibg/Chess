using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _colorOne, _colorTwo;
    [SerializeField] private SpriteRenderer _renderer;

    public void init(bool color)
    {
        if (color)
        {
            _renderer.color = _colorOne;
        }
        else
        {
            _renderer.color = _colorTwo;
        }
    }
}
