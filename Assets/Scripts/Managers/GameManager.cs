using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameManager() {}
    public bool IsPaused => Time.timeScale == 0;
    private bool IsBusy = false;
    public event Action<bool> OnPauseChanged;

    private void Awake() {
        
        if(Instance == null) {
        //PlayerPrefs.DeleteAll();
            Instance = this;
            if(gameObject.transform.parent == null) {
                DontDestroyOnLoad(gameObject);
            }
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadMenu() {
        if(IsBusy) return;
        if(IsPaused) TogglePause();
        LoadScene(GameScenes.MainMenu);
    }

    public void ResetLevel() {
        if(IsBusy) return;
        if(IsPaused) TogglePause();
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadGame() {
        if(IsPaused) TogglePause();
        var playerData = PlayerManager.Instance.Player;
        // Load first tutorial level directly if player has not completed any levels.
        if(SceneManager.GetActiveScene().name == GameScenes.MainMenu && !playerData.HasTutorialCompleted) {
            LoadScene(GameScenes.TutorialLevel);
            return;
        }

        LoadScene(GameScenes.Lobby);
    }

    public void LoadLevel(string sceneName) {
        if(IsBusy) return;
        if(IsPaused) TogglePause();
        LoadScene(sceneName);
    }

    private void LoadScene(string sceneName)
    {
        if(LevelLoader.Instance != null) {
            IsBusy = true;
            LevelLoader.Instance.Animate(() => {
                SceneManager.LoadScene(sceneName);
                IsBusy = false;
            });
        } else {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void CompleteLevel(int level) {
        if(IsBusy) return;
        var player = PlayerManager.Instance.Player;
        if(player.LevelsCompleted < level) {
            PlayerManager.Instance.UpdateLevelCompleted(level);
        }
        LoadGame();
    }

    public void CompleteTutorial() {
        if(IsBusy) return;
        PlayerManager.Instance.CompleteTutorial();
        LoadGame();
    }

    public void TogglePause() {
        if(IsPaused) {
            Time.timeScale = 1;
        } else {
            Time.timeScale = 0;
        }
        Instance.OnPauseChanged?.Invoke(IsPaused);
    }
}
