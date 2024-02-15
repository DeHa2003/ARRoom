using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionPanel : MovePanel
{
    private int sceneNumber;

    public override void ClosePanel()
    {
        if (tween != null) { tween.Kill(); }

        tween = panel.transform.DOLocalMove(from, time).OnComplete(() => 
        {
            panel.SetActive(false);
        } );
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }
    public override void OpenPanel()
    {
        if (tween != null) { tween.Kill(); }
        PlaySound();
        panel.SetActive(true);
        tween = panel.transform.DOLocalMove(to, time).OnComplete(() => 
        {
            SceneManager.LoadScene(sceneNumber);
            
        } );
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    public void SetSceneNumber(int value)
    {
        sceneNumber = value;
    }

    protected override void PlaySound()
    {
        //audioInteractor.PlayEffectSound("Whoosh");
    }
}
