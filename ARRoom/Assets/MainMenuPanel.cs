using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : Panel
{
    [SerializeField] private Panel leftPanel;
    [SerializeField] private Panel mainPanel;

    public override void Initialize()
    {
        base.Initialize();
        leftPanel.Initialize();
        mainPanel.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        leftPanel.OpenPanel();
        mainPanel.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        leftPanel.ClosePanel();
        mainPanel.ClosePanel();
    }
}
