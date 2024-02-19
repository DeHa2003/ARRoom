using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftMenuPanel : MovePanel
{
    [SerializeField] private GridLayoutGroup layoutGroup;

    public override void OpenPanel()
    {
        if (tween != null) { tween.Kill(); }

        panel.SetActive(true);

        tween = panel.transform.DOLocalMove(to, time).OnComplete(() =>
        {
            animationInteractor.ChangeGridLayoutSpacing(layoutGroup, new Vector2(0, -100), new Vector2(0, 30), 0.3f);
        });

        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    public override void ClosePanel()
    {
        if (tween != null) { tween.Kill(); }

        animationInteractor.ChangeGridLayoutSpacing(layoutGroup, new Vector2(0, 30), new Vector2(0, -100), 0.3f);

        tween = panel.transform.DOLocalMove(from, time).OnComplete(() =>
        {
            panel.SetActive(false);
        });
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }
}
