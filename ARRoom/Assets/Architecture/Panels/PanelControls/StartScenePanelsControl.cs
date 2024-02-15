using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenePanelsControl : PanelsControl
{
    [SerializeField] private Panel mainPanel;
    [SerializeField] private Panel settingsPanel;
    [SerializeField] private Panel shopPanel;

    public override void Initialize()
    {
        base.Initialize();

        mainPanel.Initialize();
        settingsPanel.Initialize();
        shopPanel.Initialize();
        //transitionPanel.Initialize();
        OpenPanel(mainPanel);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
