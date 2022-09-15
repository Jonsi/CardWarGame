using Zenject;
using UnityEngine;
using System.Collections.Generic;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CardSlotController _cardSlotControllerPlayer1;
    [SerializeField] private CardSlotController _cardSlotControllerPlayer2;


    public override void InstallBindings()
    {
        IPlayer player1 = new Player();
        IPlayer player2 = new Player();

        InstallPlayer(player1, _cardSlotControllerPlayer1);
        InstallPlayer(player2, _cardSlotControllerPlayer2);

        Container.QueueForInject(player1);
        Container.QueueForInject(player2);

        PlayerManager playerManager = new PlayerManager(new List<IPlayer>() { player1, player2 });
        Container.Bind<IPlayerManager>().FromInstance(playerManager);
        Container.QueueForInject(playerManager);

        Container.Bind<WorldEvent>().FromInstance(new WorldEvent()).AsSingle();


    }

    private void InstallPlayer(IPlayer player,CardSlotController cardSlotController)
    {
        Container.Bind<ICardSlotController>().FromInstance(cardSlotController).WhenInjectedIntoInstance(player);
    }
}