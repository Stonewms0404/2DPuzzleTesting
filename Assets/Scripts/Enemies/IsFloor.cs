using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFloor : MonoBehaviour
{
    public bool _grounded;
    private void OnTriggerStay2D(Collider2D collision)
    {
        string collTag = collision.tag;
        if (collTag == "Object" || collTag == "Tilemap")
            _grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        string collTag = collision.tag;
        if (collTag == "Object" || collTag == "Tilemap")
            _grounded = false;
    }
}
