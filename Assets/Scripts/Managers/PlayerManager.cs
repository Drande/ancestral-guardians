using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager Instance { get; private set; }
    private readonly PlayerService _playerService;
    private Player _player;
    public Player Player => _player;

    private PlayerManager() {
        if(Instance == null) {
            _playerService = new PlayerService();
        }
    }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        _player = _playerService.GetPlayer();
    }

    public Player UpdatePlayerName(string name) {
        return _playerService.UpdateName(name);
    }

    public void UpdateLevelCompleted(int level)
    {
        _playerService.UpdateLevelCompleted(level);
    }
}