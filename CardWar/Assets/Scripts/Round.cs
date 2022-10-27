using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class Round{
    private List<IPlayer> _roundPlayers;
    private Dictionary<Card, IPlayer> _cardToPlayer = new Dictionary<Card, IPlayer>();

    public Round(IPlayerManager playerManager)
    {
        _roundPlayers = playerManager.AlivePlayers().OrderBy(item => UnityEngine.Random.value).ToList();
    }
     public async UniTask Draw(bool facingUp)
    {
        var tasks = new List<UniTask<PlacedCard>>();

        foreach(var player in _roundPlayers)
        {
            var task = player.PlaceCard(facingUp);
            tasks.Add(task);
        }

        var placedCards = await UniTask.WhenAll(tasks);

        for (int i = 0; i < _roundPlayers.Count; i++)
        {
            var card = placedCards[i];

            if(card == null)
            {
                continue;
            }

            _cardToPlayer.Add(card, _roundPlayers[i]);
        }

    }

    public IPlayer CheckForWinner()
    {
        var heighestCards = _cardToPlayer.OrderBy(item => item.Key.Kind).GroupBy(item => item.Key.Kind).Last();
        return heighestCards.Count() == 1? heighestCards.First().Value : null;
    }
}