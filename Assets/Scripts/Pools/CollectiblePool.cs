using UnityEngine;
using System.Collections.Generic;

public class CollectiblePool : MonoBehaviour
{
    public static CollectiblePool Instance { get; private set; }
    private CollectiblePool() {}

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            if(gameObject.transform.parent == null) {
                DontDestroyOnLoad(gameObject);
            }
            InitializePools();
        } else {
            Destroy(gameObject);
        }
    }

    [SerializeField] private CollectiblePrefab[] prefabs;
    [SerializeField] private int poolSize = 1;
    [SerializeField] private int growthStep = 2;

    private Dictionary<CollectibleType, List<GameObject>> pools;

    /// <summary>
    /// Initializes a separate pool for each type defined in the `prefabs` array.
    /// </summary>
    private void InitializePools()
    {
        pools = new Dictionary<CollectibleType, List<GameObject>>();

        foreach (var prefab in prefabs)
        {
            var pool = new List<GameObject>();

            for (var i = 0; i < poolSize; i++)
            {
                var obj = Instantiate(prefab.prefab, transform);
                obj.SetActive(false);
                pool.Add(obj);
            }

            pools.Add(prefab.type, pool);
        }
    }

    /// <summary>
    /// Retrieves an inactive object of the specified collectible type from the pool, activates it, 
    /// and returns the GameObject. If no inactive objects are available, the pool will be expanded.
    /// </summary>
    /// <param name="type">The type of collectible object to retrieve and activate.</param>
    /// <returns>A GameObject of the specified type, activated and ready for use.</returns>
    public GameObject GetInstance(CollectibleType type) {
        var obj = GetObject(type);
        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// Retrieves an inactive object from the pool corresponding to the specified type.
    /// If no objects are available, it grows the pool.
    /// </summary>
    /// <param name="type">The type of the collectible object to retrieve.</param>
    /// <returns>A GameObject of the specified type, ready for use.</returns>
    private GameObject GetObject(CollectibleType type)
    {
        if (!pools.ContainsKey(type)) {
            Debug.LogWarning($"No pool found for type: {type}");
            return null;
        }

        var pool = pools[type];

        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // If no inactive objects are available, grow the pool
        GrowPool(type);
        return GetObject(type);
    }

    /// <summary>
    /// Expands the pool of objects for the specified type by the growth step.
    /// This ensures that there are always enough objects available for use.
    /// </summary>
    /// <param name="type">The type of objects for which the pool should be expanded.</param>
    private void GrowPool(CollectibleType type)
    {
        if (!pools.ContainsKey(type)) return;

        var pool = pools[type];

        for (var i = 0; i < growthStep; i++)
        {
            var obj = Instantiate(GetPrefabForType(type), transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    /// <summary>
    /// Finds and returns the prefab associated with the specified type.
    /// </summary>
    /// <param name="type">The type for which to retrieve the corresponding prefab.</param>
    /// <returns>The prefab GameObject that matches the specified type.</returns>
    private GameObject GetPrefabForType(CollectibleType type)
    {
        foreach (var prefab in prefabs)
        {
            if (prefab.type == type)
            {
                return prefab.prefab;
            }
        }

        return null;
    }
}
