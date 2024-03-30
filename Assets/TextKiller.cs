using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextKiller : MonoBehaviour
{
    [SerializeField]
    float timeBeforeDeath;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Destroy(gameObject, timeBeforeDeath);
    }
}
