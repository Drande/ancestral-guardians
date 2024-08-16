using System;

[Serializable]
public record Player {
    public string Name { get; set; } = string.Empty;
    public Guid AvatarId { get; set; }
    public int LevelsCompleted { get; set; } = 0;
    public bool HasTutorialCompleted { get; set; } = false;
}