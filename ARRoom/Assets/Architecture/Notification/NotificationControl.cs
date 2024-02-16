using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationControl : MonoBehaviour, INotification
{
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private Transform pos;
    [SerializeField] private Notification notificationPrefab;

    private Notification notification;

    public void CreateNotification(string hand, string description)
    {
        if (notification != null)
        {
            DestroyNotification();
        }

        notification = Instantiate(notificationPrefab);
        ChangeTransform(notification);

        notification.Initialize();
        notification.SetText(hand, description);
        notification.OpenPanel();
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

    public void DestroyNotification()
    {
        if(notification == null) { return; }

        notification.ClosePanel();
        notification = null;
    }
}
