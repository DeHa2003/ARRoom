using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemsPanel : MovePanel
{
    [SerializeField] private TimerVisualize timerVisualize;

    private RoomInteractor roomInteractor;

    public override void Initialize()
    {
        base.Initialize();
        roomInteractor = Game.GetInteractor<RoomInteractor>();
        timerVisualize.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        roomInteractor.SpawnObjects();
        timerVisualize.StartTimer(5);
    }

    public override void ClosePanel()
    {
        timerVisualize.StopTimer();
        base.ClosePanel();
    }
}
