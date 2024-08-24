using UnityEngine;

public class FollowTargetByName : MonoBehaviour
{
    [SerializeField] private string targetName;
    [SerializeField] private Vector3 offset;
    private Transform target;

    private void Start() {
        target = GameObject.Find(targetName)?.transform;
    }

    private void LateUpdate() {
        if(target != null) transform.position = target.position + offset;
    }
}
