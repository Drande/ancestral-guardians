using System;
using UnityEngine;

public class PlayerService : IPlayerService
{
    private const string PLAYER_STORAGE_KEY = "playerdata";

    public Player GetPlayer()
    {
        if (PlayerPrefs.HasKey(PLAYER_STORAGE_KEY))
        {
            var savedDataString = PlayerPrefs.GetString(PLAYER_STORAGE_KEY);
            return JsonUtility.FromJson<Player>(savedDataString);
        }
        return new Player();
    }

    public void SavePlayer(Player data)
    {
        PlayerPrefs.SetString(PLAYER_STORAGE_KEY, JsonUtility.ToJson(data));
    }

    public Player UpdateName(string name)
    {
        var player = GetPlayer();
        player.Name = name;
        SavePlayer(player);
        return player;
    }

    public Player UpdateAvatar(Guid avatarId)
    {
        var player = GetPlayer();
        player.AvatarId = avatarId;
        SavePlayer(player);
        return player;
    }
}
