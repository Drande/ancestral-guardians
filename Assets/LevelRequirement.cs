using UnityEngine;
using UnityEngine.UI;

public class LevelRequirement : MonoBehaviour
{
    [SerializeField] private int requiredLevels;
    private Button button;

    private void Start() {
        button = GetComponent<Button>();
        button.interactable = false;
        PlayerManager.Instance.SubscribeToPlayer(HandlePlayerChange);
    }

    private void HandlePlayerChange(Player player) {
        button.interactable = player.LevelsCompleted >= requiredLevels;
    }
}
