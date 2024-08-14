using TMPro;
using UnityEngine;

public class SceneTextPool : MonoBehaviour
{
    public static SceneTextPool Instance { get; private set; }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializePool(poolSize);
        } else {
            Destroy(gameObject);
        }
    }

    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 1;
    [SerializeField] private int growthStep = 2;

    private GameObject[] pool;

    private void InitializePool(int size)
    {
        pool = new GameObject[size];

        for (var i = 0; i < size; i++)
        {
            pool[i] = Instantiate(objectPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    public void DisplayAt(Vector3 position, string text) {
        var txt = GetObject();
        txt.GetComponent<RectTransform>().anchoredPosition3D = position;
        txt.SetActive(true);
        txt.GetComponent<TextMeshProUGUI>().text = text;
    }

    private GameObject GetObject()
    {
        for (var i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        // If no inactive objects are available, grow the pool
        GrowPool();
        return GetObject();
    }

    private void GrowPool()
    {
        var currentSize = pool.Length;
        var newSize = currentSize + growthStep;

        GameObject[] newPool = new GameObject[newSize];
        pool.CopyTo(newPool, 0);

        for (var i = currentSize; i < newSize; i++)
        {
            newPool[i] = Instantiate(objectPrefab, transform);
            newPool[i].SetActive(false);
        }

        pool = newPool;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
