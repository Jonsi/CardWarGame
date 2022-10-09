using Zenject;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using Zenject.SpaceFighter;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameInstaller : MonoInstaller
{
    public CardSlotController CardSlotController;
    public DeckController DeckController;
    public SlotView SlotView;
    public DeckView DeckView;

    public override void InstallBindings()
    {
        IPlayer player1 = new Player();
        IPlayer player2 = new Player();

        Container.QueueForInject(player1);
        Container.QueueForInject(player2);

        PlayerManager playerManager = new PlayerManager(new List<IPlayer>() { player1, player2 });
        Container.Bind<IPlayerManager>().FromInstance(playerManager);
        Container.QueueForInject(playerManager);

        Container.Bind<ITable>().To<Table>().AsSingle();
        Container.Bind<WorldEvent>().FromInstance(new WorldEvent()).AsSingle();

    }

    private void InstallPlayer(IPlayer player,ICardSlotController cardSlotController,ICardView deckView,ICardView slotView)
    {
        Container.Bind<ICardSlotController>().FromInstance(cardSlotController).WhenInjectedIntoInstance(player);
        Container.Bind<ICardView>().WithId("slot_view").FromInstance(slotView).WhenInjectedIntoInstance(player);
        Container.Bind<ICardView>().WithId("deck_view").FromInstance(deckView).WhenInjectedIntoInstance(player);
    }

    private void InstallPlayer(IPlayer player)
    {
        Container.Bind<ICardSlotController>().FromInstance(CardSlotController).WhenInjectedIntoInstance(player);
        Container.Bind<ICardDeckController>().FromInstance(DeckController).WhenInjectedIntoInstance(player);
        Container.Bind<ICardView>().WithId("slot_view").FromInstance(SlotView).WhenInjectedIntoInstance(player);
        Container.Bind<ICardView>().WithId("deck_view").FromInstance(DeckView).WhenInjectedIntoInstance(player);
        Container.QueueForInject(player);
    }
}