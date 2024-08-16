using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameManager() {}

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
        var playerData = PlayerManager.Instance.Player;
        // Load first tutorial level directly if player has not completed any levels.
        if(SceneManager.GetActiveScene().name == GameScenes.MainMenu && !playerData.HasTutorialCompleted) {
            SceneManager.LoadScene(GameScenes.Level);
            return;
        }

        SceneManager.LoadScene(GameScenes.Lobby);
    }

    public void LoadLevel() {
        SceneManager.LoadScene(GameScenes.Level);
    }
}
