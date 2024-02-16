using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputData : MonoBehaviour
{
    [Header("Notification")]
    [SerializeField] protected NotificationControl notificationControl;

    [Header("Audio")]
    [SerializeField] protected AudioManager audioManager;

    private NotificationInteractor notificationInteractor;
    private AudioInteractor audioInteractor;
    private SettingsInteractor settingsInteractor;
    public void Initialize()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        settingsInteractor = Game.GetInteractor<SettingsInteractor>();

        audioInteractor.SetData(audioManager);
        notificationInteractor.SetData(notificationControl);
        settingsInteractor.SetData(audioManager);
    }
}
