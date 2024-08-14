using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadMenu() {
        SceneManager.LoadScene(GameScenes.MainMenu);
    }

    public void LoadGame() {
        SceneManager.LoadScene(GameScenes.Game);
    }

    public void LoadLevel() {
        SceneManager.LoadScene(GameScenes.Level);
    }
}
