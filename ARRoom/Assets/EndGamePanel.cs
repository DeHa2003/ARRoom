using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePanel : MovePanel
{
    [SerializeField] private Panel totalScorePanel;

    public override void Initialize()
    {
        base.Initialize();
        totalScorePanel.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        totalScorePanel.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        totalScorePanel.ClosePanel();
    }
}
