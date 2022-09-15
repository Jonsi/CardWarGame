using System.Collections.Generic;

public interface IPlayerManager
{
    public IPlayer GetPlayer(int index);
    public List<IPlayer> AlivePlayers();
    public List<IPlayer> AllPlayers();
}