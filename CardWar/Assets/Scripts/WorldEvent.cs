using System;

public class WorldEvent
{
    public event Action<IPlayer> PlayerDied;

    public void OnPlayerDied(IPlayer player)
    {
        PlayerDied?.Invoke(player);
    }
}