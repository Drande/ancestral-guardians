using Unity.VisualScripting;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField] private CollectibleType collectible;
    [SerializeField] [Range(0, 1)] private float rate = 1;

    private void OnDisable() {
        if(Random.Range(0, 1f) <= rate && !CollectiblePool.Instance.IsDestroyed()) {
            var collectibleInstance = CollectiblePool.Instance.GetInstance(collectible);
            collectibleInstance.transform.position = transform.position;
        }
    }
}
