using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActivator : MonoBehaviour
{
    public GameObject player;
    private PlayerStatus playerStatus;

    private void Start()
    {
        playerStatus = player.GetComponent<PlayerStatus>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerStatus.hasKey = true;
            Destroy(gameObject);
        }
    }
}
