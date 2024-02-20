using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents_GameScene : MonoBehaviour
{
    public UnityEvent OnStartGame;
    public UnityEvent OnLoseGame;

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

        hitItemsInteractor.OnHitOther += RemoveHealth;
        hitItemsInteractor.OnHitChangeItem += DestroyItem;
        hitItemsInteractor.OnActivateFind += RestoreData;
        healthInteractor.OnPlayerOutOfLives += DiactivateFindinItems;
    }

    private void DestroyItem(Item item)
    {
        scoreInteractor.AddScore(this, 1);
        Destroy(item.gameObject);
    }

    private void RestoreData()
    {
        healthInteractor.RestoreHealth();
        scoreInteractor.RestoreScore();
    }

    public void DiactivateFindinItems()
    {
        hitItemsInteractor.ActivateFind(false);
        OnLoseGame?.Invoke();
        notificationInteractor.CreateNotification("Сообщение", "Вы проиграли");
    }

    private void RemoveHealth(Item item)
    {
        healthInteractor.RemoveHealth(this);
    }

    private void OnDestroy()
    {
        hitItemsInteractor.OnHitOther -= RemoveHealth;
        healthInteractor.OnPlayerOutOfLives -= DiactivateFindinItems;
        hitItemsInteractor.OnHitChangeItem -= DestroyItem;
        hitItemsInteractor.OnActivateFind -= RestoreData;
    }
}
