using System.Collections.Generic;
using System.Linq;

public class Round{
    private List<IPlayer> _alivePlayers;
    private Dictionary<Card, IPlayer> _cardToPlayer = new Dictionary<Card, IPlayer>();

    public Round(IPlayerManager playerManager)
    {
        _alivePlayers = playerManager.AlivePlayers().OrderBy(item => UnityEngine.Random.value).ToList();
    }
    public void Draw(bool fliped)
    {
        foreach(var player in _alivePlayers)
        {
            var card = player.DrawCard(fliped);
            if(card == null)
            {
                continue;
            }
            _cardToPlayer.Add(card, player);
        }
    }

    public IPlayer CheckForWinner()
    {
        var heighestCards = _cardToPlayer.OrderBy(item => item.Key.Kind).GroupBy(item => item.Key.Kind).Last();
        return heighestCards.Count() == 1? heighestCards.First().Value : null;
    }
}
