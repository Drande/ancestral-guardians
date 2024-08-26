using System.Collections.Generic;
using UnityEngine;

public class NamedSingleton : MonoBehaviour {
    private static Dictionary<string, NamedSingleton> Instances { get; set; } = new();
    [SerializeField] private string instanceName;
    private NamedSingleton() {}

    private void Awake() {
        if(!Instances.ContainsKey(instanceName)) {
            Instances[instanceName] = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}