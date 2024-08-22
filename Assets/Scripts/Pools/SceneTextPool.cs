using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class SceneTextPool : MonoBehaviour
{
    public static SceneTextPool Instance { get; private set; }
    private SceneTextPool() {}

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializePools();
        } else {
            Destroy(gameObject);
        }
    }

    [SerializeField] private SceneTextPrefab[] prefabs;
    [SerializeField] private int poolSize = 1;
    [SerializeField] private int growthStep = 2;

    private Dictionary<SceneTextStyle, List<GameObject>> pools;

    /// <summary>
    /// Initializes a separate pool for each style defined in the `prefabs` array.
    /// </summary>
    private void InitializePools()
    {
        pools = new Dictionary<SceneTextStyle, List<GameObject>>();

        foreach (var prefab in prefabs)
        {
            var pool = new List<GameObject>();

            for (var i = 0; i < poolSize; i++)
            {
                var obj = Instantiate(prefab.prefab, transform);
                obj.SetActive(false);
                pool.Add(obj);
            }

            pools.Add(prefab.style, pool);
        }
    }

    /// <summary>
    /// Displays a text object at the specified position with the provided text and style.
    /// </summary>
    /// <param name="position">The position in the scene where the text should appear.</param>
    /// <param name="text">The content of the text to display.</param>
    /// <param name="style">The style of the text, which determines the type of object to display.</param>
    public void DisplayAt(Vector3 position, string text, SceneTextStyle style = SceneTextStyle.Damage) {
        var txt = GetObject(style);
        if (txt == null) return;

        txt.GetComponent<RectTransform>().anchoredPosition3D = position;
        txt.SetActive(true);
        txt.GetComponent<TextMeshProUGUI>().text = text;
    }

    /// <summary>
    /// Retrieves an inactive object from the pool corresponding to the specified style.
    /// If no objects are available, it grows the pool.
    /// </summary>
    /// <param name="style">The style of the text object to retrieve.</param>
    /// <returns>A GameObject of the specified style, ready for use.</returns>
    private GameObject GetObject(SceneTextStyle style)
    {
        if (!pools.ContainsKey(style)) {
            Debug.LogWarning($"No pool found for style: {style}");
            return null;
        }

        var pool = pools[style];

        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // If no inactive objects are available, grow the pool
        GrowPool(style);
        return GetObject(style);
    }

    /// <summary>
    /// Expands the pool of objects for the specified style by the growth step.
    /// This ensures that there are always enough objects available for use.
    /// </summary>
    /// <param name="style">The style of objects for which the pool should be expanded.</param>
    private void GrowPool(SceneTextStyle style)
    {
        if (!pools.ContainsKey(style)) return;

        var pool = pools[style];

        for (var i = 0; i < growthStep; i++)
        {
            var obj = Instantiate(GetPrefabForStyle(style), transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    /// <summary>
    /// Finds and returns the prefab associated with the specified style.
    /// </summary>
    /// <param name="style">The style for which to retrieve the corresponding prefab.</param>
    /// <returns>The prefab GameObject that matches the specified style.</returns>
    private GameObject GetPrefabForStyle(SceneTextStyle style)
    {
        foreach (var prefab in prefabs)
        {
            if (prefab.style == style)
            {
                return prefab.prefab;
            }
        }

        return null;
    }
}
