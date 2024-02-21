using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationControl : MonoBehaviour, INotification
{
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private Transform pos;
    [SerializeField] private Notification notificationPrefab;
    [SerializeField] private NotificationAction notificationActionPrefab;

    private Notification notification;
    private NotificationAction actionNotification;

    public void CreateNotification(string hand, string description)
    {
        if (notification != null)
        {
            DestroyNotification();
        }

        notification = Instantiate(notificationPrefab);
        ChangeTransform(notification);

        notification.Initialize();
        notification.SetData(hand, description);
        notification.OpenPanel();
    }

    public void CreateActionNotification(Action action, string description)
    {
        if (actionNotification != null)
        {
            DestroyActionNotification();
        }

        actionNotification = Instantiate(notificationActionPrefab);

        actionNotification.Initialize();
        actionNotification.SetData(action, description);
        actionNotification.OpenPanel();
    }

    public void DestroyActionNotification()
    {
        if (actionNotification == null) { return; }

        actionNotification.ClosePanel();
        actionNotification = null;
    }

    public void DestroyNotification()
    {
        if(notification == null) { return; }

        notification.ClosePanel();
        notification = null;
    }

    private void ChangeTransform(Notification notification)
    {
        if (notification.TryGetComponent(out RectTransform rectTransform))
        {
            rectTransform.SetParent(canvasTransform);
            rectTransform.position = pos.position;
            rectTransform.localScale = Vector3.one;
            rectTransform.rotation = canvasTransform.rotation;
        }
    }
}
