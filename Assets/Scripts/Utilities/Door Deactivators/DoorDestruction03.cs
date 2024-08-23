using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestruction03 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] doorsToDestroy = GameObject.FindGameObjectsWithTag("DestructDoor03");

            foreach (GameObject door in doorsToDestroy)
            {
                Destroy(door);
            }
        }
    }

}
