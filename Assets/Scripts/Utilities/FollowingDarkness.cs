using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingDarkness : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position;
        }
    }
}
