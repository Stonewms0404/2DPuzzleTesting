using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateHead : MonoBehaviour
{
    public SwitchScript swich;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!swich.IsOn)
        {
            if (collision.CompareTag("Object"))
            {
                swich.ToggleSwitch();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (swich.IsOn)
        {
            if (collision.CompareTag("Object"))
                swich.ToggleSwitch();
        }
    }
}
