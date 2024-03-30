using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextHolder : MonoBehaviour
{
    [SerializeField]
    GameObject textToActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textToActivate.SetActive(true);
            Destroy(gameObject);
        }
    }
}
