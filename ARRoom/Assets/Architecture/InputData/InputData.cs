using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputData : MonoBehaviour
{
    [Header("Notification")]
    [SerializeField] protected NotificationControl notificationControl;
    [SerializeField] protected Notification notification;

    [Header("Audio")]
    [SerializeField] protected AudioManager audioManager;

    protected NotificationInteractor notificationInteractor;
    protected AudioInteractor audioInteractor;

    public virtual void Initialize()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();

        notificationInteractor.SetData(notificationControl);
        //audioInteractor.SetData(audioManager, );
    }
}
