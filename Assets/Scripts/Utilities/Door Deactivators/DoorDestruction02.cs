using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestruction02 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] doorsToDestroy = GameObject.FindGameObjectsWithTag("DestructDoor02");

            foreach (GameObject door in doorsToDestroy)
            {
                Destroy(door);
            }
        }
    }

}
