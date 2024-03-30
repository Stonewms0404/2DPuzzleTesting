using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoors : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    [Tooltip("The GameObjects of the triggers")]
    GameObject[] doorTriggers;

    public void RoomFinished()
    {
        foreach (GameObject trigger in doorTriggers)
            trigger.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
