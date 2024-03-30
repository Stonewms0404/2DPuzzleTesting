using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHead : MonoBehaviour
{
    public SwitchScript swich;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            swich.ToggleSwitch();
        }
    }
}
