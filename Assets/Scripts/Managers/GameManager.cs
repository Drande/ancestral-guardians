using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameManager() {}
    public bool IsPaused => Time.timeScale == 0;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            if(gameObject.transform.parent == null) {
                DontDestroyOnLoad(gameObject);
            }
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadMenu() {
        SceneManager.LoadScene(GameScenes.MainMenu);
    }

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadGame() {
        var playerData = PlayerManager.Instance.Player;
        // Load first tutorial level directly if player has not completed any levels.
        if(SceneManager.GetActiveScene().name == GameScenes.MainMenu && !playerData.HasTutorialCompleted) {
            SceneManager.LoadScene(GameScenes.TutorialLevel);
            return;
        }

        SceneManager.LoadScene(GameScenes.Lobby);
    }

    public void LoadLevel(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void CompleteLevel(int level) {
        var player = PlayerManager.Instance.Player;
        if(player.LevelsCompleted < level) {
            PlayerManager.Instance.UpdateLevelCompleted(level);
        }
        LoadGame();
    }

    public void CompleteTutorial() {
        PlayerManager.Instance.CompleteTutorial();
        LoadGame();
    }

    public void TogglePause() {
        if(IsPaused) {
            Time.timeScale = 1;
        } else {
            Time.timeScale = 0;
        }
    }
}
