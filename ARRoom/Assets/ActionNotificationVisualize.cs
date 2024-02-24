using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionNotificationVisualize : MonoBehaviour
{
    public UnityEvent actionToNotification;

    private NotificationInteractor notificationInteractor;

    public void Initialize()
    {
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
    }

    public void SendAction(string description)
    {
        notificationInteractor.CreateCustomActionNotification(Action, description);
    }

    private void Action()
    {
        actionToNotification.Invoke();
    }
}
