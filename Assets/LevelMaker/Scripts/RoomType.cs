using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    [Header("Room Information")]
    [SerializeField]
    [Tooltip("The Room's Name")]
    string _name;
    [SerializeField]
    [Tooltip("Description of the room's elements")]
    [TextArea]
    string _description;
    [SerializeField]
    [Tooltip("The type of room")]
    private TypeOfRoom _roomType;
    [SerializeField]
    [Tooltip("The Doors of the room to lock the player inside")]
    GameObject[] roomDoors;
    [SerializeField]
    [Tooltip("The Switches in the room to check if the player can be let go")]
    SwitchScript[] switches;

    bool roomFinished;
    private bool inRoom;

    public TypeOfRoom RType => _roomType;

    private void Start()
    {
        if (roomDoors.Length != 0)
            OpenDoors();
        name = _name;
    }

    private void OnEnable()
    {
        RoomTrigger.PlayerEnterRoom += CheckRoom;
        SwitchScript.SwitchFlipped += CheckRoomFinished;
    }
    private void OnDestroy()
    {
        RoomTrigger.PlayerEnterRoom -= CheckRoom;
        SwitchScript.SwitchFlipped -= CheckRoomFinished;
    }

    private void Update()
    {
        if (inRoom)
        {
            CheckRoomFinished();
            if (roomFinished)
                OpenDoors();
            else
                CloseDoors();
        }
        else
            OpenDoors();
    }

    private void CheckRoom(Vector2 pos)
    {
        if (roomDoors.Length != 0)
        {
            CheckRoomFinished();
            if ((Vector2)transform.position == pos && !roomFinished)
            {
                CloseDoors();
            }
            else
            {
                OpenDoors();
            }
        }
    }

    private void CheckRoomFinished()
    {
        if (switches.Length != 0)
        {
            foreach (SwitchScript swit in switches)
            {
                if (!swit.IsOn)
                {
                    roomFinished = false;
                    return;
                }
                else
                {
                    roomFinished = true;
                }
            }
        }
        else
            roomFinished = true;
            
    }

    private void CloseDoors()
    {
        foreach (GameObject door in roomDoors)
            door.SetActive(true);
        inRoom = true;
    }

    private void OpenDoors()
    {
        foreach (GameObject door in roomDoors)
            door.SetActive(false);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.TryGetComponent<RoomType>(out RoomType room);
        if (room != null)
            Destroy(collision.gameObject);
    }
}

public enum TypeOfRoom
{
    LR,
    LRB,
    LRT,
    LRBT
}