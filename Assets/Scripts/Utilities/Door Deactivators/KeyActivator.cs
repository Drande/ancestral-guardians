using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActivator : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerStatus;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Start()
    {
        playerStatus = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerStatus.hasKey = true;
            Debug.Log("Llave obtenida");
            Destroy(gameObject);
        }
    }
}
