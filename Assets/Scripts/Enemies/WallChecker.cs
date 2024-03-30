using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    bool _hasWall;
    bool _hasEnemy;

    public bool HasWall => _hasWall;
    public bool HasEnemy => _hasEnemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tilemap"))
            _hasWall = true;
        if (collision.CompareTag("Enemy"))
            _hasEnemy = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tilemap"))
            _hasWall = false;
        if (collision.CompareTag("Enemy"))
            _hasEnemy = true;
    }
}
