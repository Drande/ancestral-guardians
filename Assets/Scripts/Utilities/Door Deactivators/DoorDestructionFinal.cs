using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestructionFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] doorsToDestroy = GameObject.FindGameObjectsWithTag("FinalDoor");

            foreach (GameObject door in doorsToDestroy)
            {
                Destroy(door);
            }
        }
    }

}
