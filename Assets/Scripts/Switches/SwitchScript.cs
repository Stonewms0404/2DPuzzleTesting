using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public static event Action SwitchFlipped;

    [Header("Objects")]
    [SerializeField]
    [Tooltip("The objects that will need to be toggled to turn on or off the switch")]
    GameObject[] objects;

    bool isOn = false;

    public bool IsOn => isOn;

    public void ToggleSwitch()
    {
        isOn = !isOn;
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(!objects[i].activeSelf);
        }
        if (gameObject.activeSelf)
            SwitchFlipped();
    }


}
