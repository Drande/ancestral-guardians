using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInterface : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

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
}
