using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager Instance { get; private set; }
    private readonly PlayerService _playerService;
    private Player _player;
    public Player Player => _player;
    [HideInInspector] public event Action<Player> OnPlayerChanged;

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
        OnPlayerChanged?.Invoke(_player);
    }

    public Player UpdatePlayerName(string name) {
        _player = _playerService.UpdateName(name);
        OnPlayerChanged?.Invoke(_player);
        return _player;
    }

    public void UpdateLevelCompleted(int level)
    {
        _player = _playerService.UpdateLevelCompleted(level);
        OnPlayerChanged?.Invoke(_player);
    }

    public void CompleteTutorial()
    {
        _player.HasTutorialCompleted = true;
        _player = _playerService.UpdatePlayer(_player);
        OnPlayerChanged?.Invoke(_player);
    }

    public void SubscribeToPlayer(Action<Player> onLoaded) {
        if(_player != null) {
            onLoaded.Invoke(_player);
        }
        OnPlayerChanged += onLoaded;
    }

    private void OnDestroy() {
        OnPlayerChanged = null;
    }
}