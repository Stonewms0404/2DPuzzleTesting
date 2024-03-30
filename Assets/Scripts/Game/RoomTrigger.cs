using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomTrigger : MonoBehaviour
{
    public static event Action<Vector2> PlayerEnterRoom;

    GameObject[] lights;
    static GameObject room = null;
    bool lightsOn, allLightsOn;
    int index = 0;
    float timer = 0, timerToReach = 0.2f;

    private void Update()
    {
        if (lightsOn && !allLightsOn)
        {
            if (timer < timerToReach)
                timer += Time.deltaTime;
            else
            {
                LightsOn();
            }
        }
    }

    private void LightsOn()
    {
        if (index < lights.Length)
            lights[index].SetActive(true);
        else
            allLightsOn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lights = GameObject.FindGameObjectsWithTag("Light");
            PlayerEnterRoom(transform.position);
            lightsOn = true;
        }
        else if (collision.CompareTag("Room"))
        {
            if (room == null)
                room = collision.gameObject;
            else
                Destroy(collision.gameObject);
        }
    }
}
