using System;
using UnityEngine;

[Serializable]
public record Player {
    public string Name = string.Empty;
    public Guid AvatarId;
    public int LevelsCompleted;
    public bool HasTutorialCompleted;
}