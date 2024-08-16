using System;

/// <summary>
/// Defines methods for managing player data.
/// </summary>
public interface IPlayerService
{
    /// <summary>
    /// Retrieves the current player data.
    /// </summary>
    /// <returns>The current <see cref="Player"/> object.</returns>
    Player GetPlayer();
    
    /// <summary>
    /// Saves the provided player data.
    /// </summary>
    /// <param name="data">The <see cref="Player"/> object to save.</param>
    void SavePlayer(Player data);
    
    /// <summary>
    /// Updates the player's name and returns the updated player object.
    /// </summary>
    /// <param name="name">The new name to set for the player.</param>
    /// <returns>The updated <see cref="Player"/> object with the new name.</returns>
    Player UpdateName(string name);
    
    /// <summary>
    /// Updates the player's avatar ID and returns the updated player object.
    /// </summary>
    /// <param name="avatarId">The new avatar ID to set for the player.</param>
    /// <returns>The updated <see cref="Player"/> object with the new avatar ID.</returns>
    Player UpdateAvatar(Guid avatarId);
}
