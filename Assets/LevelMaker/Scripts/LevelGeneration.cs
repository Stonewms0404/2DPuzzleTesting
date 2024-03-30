using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    [Tooltip("The position at which the game will start")]
    Transform[] startingPositions;
    [SerializeField]
    [Tooltip("The Rooms to be spawned")]
    GameObject[] rooms; //i = 0 -> LR, i = 1 -> LRB, i = 2 -> LRT, i = 3 -> LRBT
    [SerializeField]
    [Tooltip("Every other room that does not necessarily have  have side pieces to it")]
    GameObject[] otherRooms;
    [SerializeField]
    [Tooltip("The First room to be spawned with the player in it")]
    GameObject[] startRoom;
    [SerializeField]
    [Tooltip("The Final room to be spawned with the player in it")]
    GameObject finishRoom;
    [SerializeField]
    [Tooltip("The empty object that the rooms will spawn to")]
    GameObject roomFolder;

    [Space]
    [Header("Variables")]
    [SerializeField]
    [Tooltip("The Amount that the rooms move per each iteration")]
    float moveAmount;
    [SerializeField]
    [Tooltip("Bounds of the generation box")]
    float minX, maxX, minY;
    [SerializeField]
    [Tooltip("The time between the initial path")]
    float timeBtwRoomsToReach;

    System.Random rand = new();
    int direction;
    float timeBtwRooms;
    [SerializeField]
    bool stopGeneration = false, isTutorial = false;

    public bool StopGeneration => stopGeneration;
    public bool IsTutorial => isTutorial;


    void Start()
    {
        if (!isTutorial)
        {
            int randStartingPos = rand.Next(0, startingPositions.Length - 1);
            transform.position = startingPositions[randStartingPos].position;

            if (transform.position.x == maxX)
            {
                direction = rand.Next(3, 5);
            }
            else if (transform.position.x == minX)
            {
                direction = rand.Next(1, 5);
                switch (direction)
                {
                    case 1: case 2: case 3:
                        direction = 2;
                        break;
                    case 4: case 5:
                        direction = 5;
                        break;
                }
            }
            else
            {
                direction = rand.Next(1, 5);
            }

            if (direction != 5)
                SpawnRandomRoom(startRoom);
            else
                SpawnBottomPiece(startRoom[3]);
        }
    }

    private void Update()
    {
        if (!stopGeneration && !isTutorial)
        {
            if (timeBtwRooms >= timeBtwRoomsToReach)
            {
                timeBtwRooms = 0;
                Move();
            }
            else
                timeBtwRooms += Time.deltaTime;
        }
    }

    private void Move()
    {
        switch (direction)
        {
            case 1: case 2: // Moves Right
                if (transform.position.x < maxX)
                {
                    transform.position = new(transform.position.x + moveAmount, transform.position.y);

                    // Checks if the position is at the bottom level or not.
                    if (transform.position.y == minY)
                    {
                        // Checks if it is all the way right.
                        if (transform.position.x == maxX)
                        {
                            SpawnFinalRoom();
                            stopGeneration = true;
                            break;
                        }
                        else
                        {
                            direction = rand.Next(1, 5);
                            switch (direction)
                            {
                                case 1: case 2: case 3:
                                    direction = 2;
                                    break;
                                case 4: case 5:
                                    direction = 5;
                                    break;
                            }
                        }

                        if (direction == 5)
                        {
                            SpawnFinalRoom();
                            stopGeneration = true;
                            break;
                        }
                    }
                    else
                    {
                        // Checks if it is all the way right.
                        if (transform.position.x == maxX)
                        {
                            direction = 5;
                        }
                        else
                        {
                            direction = rand.Next(1, 5);
                            switch (direction)
                            {
                                case 1: case 2: case 3:
                                    direction = 2;
                                    break;
                                case 4: case 5:
                                    direction = 5;
                                    break;
                            }
                        }
                    }
                }
                else
                    direction = 5;

                if (direction == 5)
                    SpawnBottomPiece();
                else
                    SpawnRandomRoom();
                break;
            case 3: case 4: // Moves Left
                if (transform.position.x > minX)
                {
                    transform.position = new(transform.position.x - moveAmount, transform.position.y);

                    // Checks if the position is at the bottom level or not.
                    if (transform.position.y == minY)
                    {
                        // Checks if it is all the way left.
                        if (transform.position.x == minX)
                        {
                            SpawnFinalRoom();
                            stopGeneration = true;
                            break;
                        }
                        else
                            direction = rand.Next(3, 5);

                        if (direction == 5)
                        {
                            SpawnFinalRoom();
                            stopGeneration = true;
                            break;
                        }
                    }
                    else
                    {
                        // Checks if it is all the way left.
                        if (transform.position.x == minX)
                        {
                            direction = 5;
                        }
                        else
                            direction = rand.Next(3, 5);
                    }
                }
                else
                    direction = 5;

                switch (direction)
                {
                    case 3: case 4:
                        SpawnRandomRoom();
                        break;
                    case 5:
                        SpawnBottomPiece();
                        break;
                }
                break;
            case 5: // Moves Down
                if (transform.position.y > minY)
                {
                    transform.position = new(transform.position.x, transform.position.y - moveAmount);

                    // Checks if the position is at the bottom level or not.
                    if (transform.position.y == minY)
                    {
                        // Checks if it is all the way right or left.
                        if (transform.position.x == maxX || transform.position.x == minX)
                        {
                            SpawnFinalRoom();
                            stopGeneration = true;
                            break;
                        }
                        else
                            direction = rand.Next(1, 5);

                        if (direction == 5)
                        {
                            SpawnFinalRoom();
                            stopGeneration = true;
                            break;
                        }
                    }
                    else
                    {
                        // Checks if it is all the way right.
                        if (transform.position.x == maxX)
                        {
                            direction = rand.Next(3, 5);
                        }
                        else if (transform.position.x == minX)
                        {
                            direction = rand.Next(1, 5);
                            switch (direction)
                            {
                                case 1: case 2: case 3:
                                    direction = 2;
                                    break;
                                case 4: case 5:
                                    direction = 5;
                                    break;
                            }
                        }
                        else
                            direction = rand.Next(1, 5);
                    }

                    if (direction == 5)
                        SpawnBottomPiece();
                    else
                        SpawnTopPiece();
                }
                else
                    stopGeneration = true;
                break;
        }
    }

    private void SpawnFinalRoom()
    {
        Instantiate(finishRoom, transform.position, Quaternion.identity, roomFolder.transform);
    }

    public void SpawnRandomRoom()
    {
        bool canSpawn = true;
        RoomType[] Crooms = roomFolder.GetComponentsInChildren<RoomType>();
        foreach (RoomType room in Crooms)
        {
            if (transform.position == room.gameObject.transform.position)
            {
                canSpawn = false;
                break;
            }
        }

        if (canSpawn)
        {
            int randRoom = rand.Next(0, rooms.Length - 1);
            Instantiate(rooms[randRoom], transform.position, Quaternion.identity, roomFolder.transform);
        }
    }
    public void SpawnRandomRoom(GameObject[] roomObj)
    {
        bool canSpawn = true;
        RoomType[] Crooms = roomFolder.GetComponentsInChildren<RoomType>();
        foreach (RoomType room in Crooms)
        {
            if (transform.position == room.gameObject.transform.position)
            {
                canSpawn = false;
                break;
            }
        }

        if (canSpawn)
        {
            int randRoom = rand.Next(0, rooms.Length - 1);
            Instantiate(roomObj[randRoom], transform.position, Quaternion.identity, roomFolder.transform);
        }

    }
    public void SpawnRandomRoom(Vector2 pos)
    {
        if (pos != (Vector2)transform.position)
        {
            int randRoom = rand.Next(0, otherRooms.Length - 1);
            Instantiate(otherRooms[randRoom], pos, Quaternion.identity, roomFolder.transform);
        }
    }

    void SpawnBottomPiece(GameObject roomObj)
    {
        Instantiate(roomObj, transform.position, Quaternion.identity, roomFolder.transform);
    }
    void SpawnBottomPiece()
    {
        bool canSpawn = true;
        RoomType[] Crooms = roomFolder.GetComponentsInChildren<RoomType>();
        foreach (RoomType room in Crooms)
        {
            if (transform.position == room.gameObject.transform.position)
            {
                canSpawn = false;
                break;
            }
        }

        if (canSpawn)
        {
            Instantiate(rooms[3], transform.position, Quaternion.identity, roomFolder.transform);
        }
    }

    void SpawnTopPiece()
    {
        bool canSpawn = true;
        RoomType[] Crooms = roomFolder.GetComponentsInChildren<RoomType>();
        foreach (RoomType room in Crooms)
        {
            if (transform.position == room.gameObject.transform.position)
            {
                canSpawn = false;
                break;
            }
        }

        if (canSpawn)
        {
            int randNum = rand.Next(2, 4);
            Instantiate(rooms[randNum], transform.position, Quaternion.identity, roomFolder.transform);
        }
    }
}
