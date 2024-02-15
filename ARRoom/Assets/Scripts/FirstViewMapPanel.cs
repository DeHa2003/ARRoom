using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstViewMapPanel : Panel
{
    [SerializeField] private TimerVisualize panelTimer;

    private RoomInteractor roomInteractor;

    public override void Initialize()
    {
        base.Initialize();

        roomInteractor = Game.GetInteractor<RoomInteractor>();
        panelTimer.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        roomInteractor.BuildRoom();

        panelTimer.OnFinishTimerEvent.AddListener(() =>
        {
            roomInteractor.HideRoom();
        });
        panelTimer.StartTimer(15);
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        panelTimer.StopTimer();
    }
}
