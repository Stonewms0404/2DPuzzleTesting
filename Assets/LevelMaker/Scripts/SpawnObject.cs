using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    [Tooltip("Objects that will be spawned at spawnpoints")]
    GameObject[] objects;

    private void Start()
    {
        System.Random rand = new();
        int randNum = rand.Next(0, objects.Length);
        GameObject instance = (GameObject)Instantiate(objects[randNum], transform.position, Quaternion.identity);
        instance.TryGetComponent<PlayerMovement>(out PlayerMovement player);
        if (player == null)
            instance.transform.parent = transform;
    }
}
