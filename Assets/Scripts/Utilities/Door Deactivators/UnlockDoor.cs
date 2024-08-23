using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject player;
    private PlayerStatus playerStatus;

    private bool isUnlockable;
    private void Start()
    {
        playerStatus = player.GetComponent<PlayerStatus>();
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
