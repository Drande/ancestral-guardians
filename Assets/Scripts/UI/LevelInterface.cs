using UnityEngine;

public class LevelInterface : MonoBehaviour
{
    public static LevelInterface Instance { get; private set; }
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject wonPanel;
    [SerializeField] private string gameOverSfx, wonSfx;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameManager.Instance.OnPauseChanged += HandlePauseChanged;
    }

    private void HandlePauseChanged(bool isPaused) {
        pausePanel.SetActive(isPaused);
    }

    private void OnDestroy() {
        GameManager.Instance.OnPauseChanged -= HandlePauseChanged;
    }

    public void GameOver() {
        AudioManager.Instance.PlaySFX(gameOverSfx);
        Instance.gameOverPanel.SetActive(true);
    }

    public void Won() {
        AudioManager.Instance.PlaySFX(wonSfx);
        Instance.wonPanel.SetActive(true);
    }
}
