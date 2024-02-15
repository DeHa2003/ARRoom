using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents_GameScene : MonoBehaviour
{
    private HealthInteractor healthInteractor;
    private HitItemsInteractor hitItemsInteractor;

    public void Initialize()
    {
        healthInteractor = Game.GetInteractor<HealthInteractor>();
        hitItemsInteractor = Game.GetInteractor<HitItemsInteractor>();

        hitItemsInteractor.OnHitOther += RemoveHealth;
        healthInteractor.OnPlayerOutOfLives += DiactivateFindinItems;
    }

    public void DiactivateFindinItems()
    {
        Debug.Log("Вы проиграли");
        hitItemsInteractor.ActivateFind(false);
    }

    private void RemoveHealth(string name)
    {
        healthInteractor.RemoveHealth(this);
    }

    private void OnDestroy()
    {
        hitItemsInteractor.OnHitOther -= RemoveHealth;
    }
}
