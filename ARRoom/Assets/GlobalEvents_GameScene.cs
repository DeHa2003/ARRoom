using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents_GameScene : MonoBehaviour
{
    public UnityEvent OnStartGameEvent;
    public UnityEvent OnLoseGameEvent;

    private HealthInteractor healthInteractor;
    private HitItemsInteractor hitItemsInteractor;
    private NotificationInteractor notificationInteractor;
    private ScoreInteractor scoreInteractor;

    public void Initialize()
    {
        healthInteractor = Game.GetInteractor<HealthInteractor>();
        hitItemsInteractor = Game.GetInteractor<HitItemsInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();

        hitItemsInteractor.OnHitOther += OnHitOther;
        hitItemsInteractor.OnHitChangeItem += OnHitSuccess;
        healthInteractor.OnPlayerOutOfLives += OnLoseGame;
    }

    private void OnHitSuccess(Item item)
    {
        notificationInteractor.CreateCustomNotification("Сообщение", "Предмет " + item.NameItem + " был найден");
        scoreInteractor.AddScore(1);
        scoreInteractor.AddSuccessHitCount();
        Destroy(item.gameObject);
    }

    private void OnHitOther(Item item)
    {
        scoreInteractor.AddLoseHitCount();
        healthInteractor.RemoveHealth();
    }

    public void OnLoseGame()
    {
        hitItemsInteractor.ActivateFind(false);
        OnLoseGameEvent?.Invoke();
    }

    private void OnDestroy()
    {
        hitItemsInteractor.OnHitOther -= OnHitOther;
        healthInteractor.OnPlayerOutOfLives -= OnLoseGame;
        hitItemsInteractor.OnHitChangeItem -= OnHitSuccess;
        
    }
}
