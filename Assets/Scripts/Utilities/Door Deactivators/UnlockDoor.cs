using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerStatus;

    private bool isUnlockable;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Start()
    {
        playerStatus = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        isUnlockable = playerStatus.hasKey;   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && isUnlockable == true)
        {
            gameObject.SetActive(false);
            playerStatus.hasKey = false;
            if (transform.parent != null)
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
