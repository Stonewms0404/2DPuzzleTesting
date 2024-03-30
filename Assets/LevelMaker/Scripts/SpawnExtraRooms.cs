using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExtraRooms : MonoBehaviour
{
    public LevelGeneration levelGen;
    
    void Update()
    {
        if (levelGen.transform.position == transform.position)
            Destroy(gameObject);
        else if (levelGen.StopGeneration)
        {
            levelGen.SpawnRandomRoom(transform.position);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.position == transform.position)
            Destroy(this.gameObject);
    }
}
