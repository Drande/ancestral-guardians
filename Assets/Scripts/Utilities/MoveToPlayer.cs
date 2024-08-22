using System.Collections;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private const float MovementDuration = 0.5f;
    private const float SearchDelay = 1f;

    private void Start()
    {
        StartCoroutine(FindPlayer());
    }

    private IEnumerator FindPlayer() {
        var wait = new WaitForSeconds(SearchDelay);
        while(true) {
            playerTransform = GameObject.Find("Player")?.transform;
            if(playerTransform == null) {
                yield return wait;
            } else {
                break;
            }
        }
        StartCoroutine(MoveTowardsTarget());
    }

    private IEnumerator MoveTowardsTarget()
    {
        var startPosition = transform.position;
        var elapsedTime = 0f;

        while (elapsedTime < MovementDuration)
        {
            // Check in case the player dies.
            if(playerTransform == null) {
                StartCoroutine(FindPlayer());
                break;
            }
            transform.position = Vector3.Lerp(startPosition, playerTransform.position, elapsedTime / MovementDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
