using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate() {
        if(target != null) transform.position = target.position;
    }
}
