using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationAction : MovePanel
{
    [SerializeField] private TextMeshProUGUI textDescription;
    [SerializeField] private Button buttonYes;
    [SerializeField] private Button buttonNo;

    private Action action;

    public override void Initialize()
    {
        base.Initialize();

        buttonYes.onClick.AddListener(ActionYes);
        buttonNo.onClick.AddListener(ClosePanel);
    }

    public void SetData(Action action, string description)
    {
        this.action = action;
        textDescription.text = description;
    }

    public void ActionYes()
    {
        action?.Invoke();
    }

    public override void OpenPanel()
    {
        panel.SetActive(true);
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    public override void ClosePanel()
    {
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time, DestroyObject);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
