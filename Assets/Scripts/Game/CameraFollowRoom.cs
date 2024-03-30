using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRoom : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    [Tooltip("The World Generation object")]
    LevelGeneration levelGen;

    private void OnEnable()
    {
        RoomTrigger.PlayerEnterRoom += SnapCamera;
    }
    private void OnDestroy()
    {
        RoomTrigger.PlayerEnterRoom -= SnapCamera;
    }

    private void SnapCamera(Vector2 pos)
    {
        transform.position = new (pos.x, pos.y, -10);
        Camera.main.orthographicSize = 6;
    }
}
