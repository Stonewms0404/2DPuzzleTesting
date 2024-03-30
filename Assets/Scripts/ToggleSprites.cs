using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSprites : MonoBehaviour
{
    [SerializeField]
    Image sprite;
    [SerializeField]
    string toggleType;

    private void Awake()
    {
        SettingsManager.ChangeSprite += ChangeSprite;
    }
    private void OnDestroy()
    {
        SettingsManager.ChangeSprite -= ChangeSprite;
    }

    private void ChangeSprite(bool value, string type)
    {
        if (type == toggleType)
            Toggle(value);
    }

    public void Toggle(bool value)
    {
        if (value)
            sprite.color = Color.green;
        else
            sprite.color = Color.red;
    }
}
