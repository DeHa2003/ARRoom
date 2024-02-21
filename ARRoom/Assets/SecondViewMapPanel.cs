using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondViewMapPanel : MovePanel
{
    [SerializeField] private HealthVisualize healthVisualize;
    [SerializeField] private ScoreVisualize scoreVisualize;
    [SerializeField] private TimerVisualize timerVisualize;

    private HitItemsInteractor findItemsInteractor;
    private RoomInteractor roomInteractor;
    //private NotificationInteractor notificationInteractor;

    public override void Initialize()
    {
        base.Initialize();

        roomInteractor = Game.GetInteractor<RoomInteractor>();
        findItemsInteractor = Game.GetInteractor<HitItemsInteractor>();
        //notificationInteractor = Game.GetInteractor<NotificationInteractor>();

        healthVisualize.Initialize();
        scoreVisualize.Initialize();
        timerVisualize.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        findItemsInteractor.ActivateFind(true);
        roomInteractor.ShowRoom();
        timerVisualize.StartTimer(60);
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        //notificationInteractor.DestroyActionNotification();
        roomInteractor.HideRoom(OnComplete: roomInteractor.DestroyCurrentRoom);
        timerVisualize.StopTimer();
        findItemsInteractor.ActivateFind(false);
    }

    //public void Exit(Action action)
    //{
    //    notificationInteractor.CreateActionNotification(action, "Прогресс не будет сохранён. Вы уверены, что хотите выйти?");
    //}
}
