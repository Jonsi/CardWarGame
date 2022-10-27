using Zenject;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using Zenject.SpaceFighter;
using static UnityEditor.Experimental.GraphView.GraphView;
using System.Linq;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private int _numPlayers = 2;
    [SerializeField] private Table _table;
    [SerializeField] private CardAnimator _cardAnimator;
    [SerializeField] private DeckView _cardsStackView;
    [SerializeField] private DeckController _cardStack;

    public override void InstallBindings()
    {
        var playerToTableSlot = new Dictionary<IPlayer, TableSlot>();
        var players = new List<IPlayer>();

        for(int i = 0; i < _numPlayers; i++)
        {
            var player = new Player();
            Container.QueueForInject(player);
            var tableSlot = _table.GetSlot(i);
            Container.Bind<TableSlot>().FromInstance(tableSlot).WhenInjectedIntoInstance(player);
            playerToTableSlot.Add(player, tableSlot);
            players.Add(player);
        }
        Container.QueueForInject(_cardAnimator);
        Container.Bind<ICardAnimator>().FromInstance(_cardAnimator);
        Container.Bind<ICardView>().WithId("cards_stack").FromInstance(_cardsStackView);
        Container.Bind<ICardDeckController>().FromInstance(_cardStack).WhenInjectedInto<GameFlowController>();
        PlayerManager playerManager = new PlayerManager(players);
        Container.Bind<IPlayerManager>().FromInstance(playerManager);
        Container.Bind<Dictionary<IPlayer, TableSlot>>().FromInstance(playerToTableSlot);
        Container.QueueForInject(playerManager);

        Container.Bind<WorldEvent>().FromInstance(new WorldEvent()).AsSingle();

    }
}