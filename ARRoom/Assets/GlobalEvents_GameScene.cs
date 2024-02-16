using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents_GameScene : MonoBehaviour
{
    private HealthInteractor healthInteractor;
    private HitItemsInteractor hitItemsInteractor;
    private NotificationInteractor notificationInteractor;

    public void Initialize()
    {
        healthInteractor = Game.GetInteractor<HealthInteractor>();
        hitItemsInteractor = Game.GetInteractor<HitItemsInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();

        hitItemsInteractor.OnHitOther += RemoveHealth;
        healthInteractor.OnPlayerOutOfLives += DiactivateFindinItems;
    }

    public void DiactivateFindinItems()
    {
        hitItemsInteractor.ActivateFind(false);
        notificationInteractor.CreateNotification("Сообщение", "Вы проиграли");
    }

    private void RemoveHealth(string name)
    {
        notificationInteractor.CreateNotification("Сообщение", "Минус жизка");
        healthInteractor.RemoveHealth(this);
    }

    private void OnDestroy()
    {
        hitItemsInteractor.OnHitOther -= RemoveHealth;
        healthInteractor.OnPlayerOutOfLives -= DiactivateFindinItems;
    }
}
