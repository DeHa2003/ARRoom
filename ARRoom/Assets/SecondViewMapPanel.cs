using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondViewMapPanel : Panel
{
    [SerializeField] private HealthVisualize healthVisualize;
    [SerializeField] private TimerVisualize timerVisualize;

    private HitItemsInteractor findItemsInteractor;
    private RoomInteractor roomInteractor;

    public override void Initialize()
    {
        base.Initialize();

        roomInteractor = Game.GetInteractor<RoomInteractor>();
        findItemsInteractor = Game.GetInteractor<HitItemsInteractor>();

        healthVisualize.Initialize();
        timerVisualize.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        findItemsInteractor.ActivateFind(true);
        roomInteractor.SpawnObjects();

        timerVisualize.OnFinishTimerEvent.AddListener(() =>
        {
            roomInteractor.ShowRoom();
        });
        timerVisualize.StartTimer(5);
    }

    public override void ClosePanel()
    {
        base.ClosePanel();

        findItemsInteractor.ActivateFind(false);
    }
}
