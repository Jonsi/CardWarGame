using System;
using System.Linq;
using System.Collections.Generic;
using Zenject;
public class PlayerManager : IPlayerManager
{
    private List<IPlayer> _players;
    private List<IPlayer> _alivePlayers;

    [Inject]
    private WorldEvent _worldEvent;

    public PlayerManager(List<IPlayer> players)
    {
        _players = players;
        _alivePlayers = players;
    }
    
    [Inject]
    public void Init()
    {
        _worldEvent.PlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied(IPlayer player)
    {
        _alivePlayers.Remove(player);
    }

    public List<IPlayer> AlivePlayers()
    {
        return _alivePlayers.ToList();
    }

    public IPlayer GetPlayer(int index)
    {
        return _players[index];
    }

    public int PlayerCount()
    {
        return _players.Count;
    }

    public List<IPlayer> AllPlayers()
    {
        return _players.ToList();
    }
}
