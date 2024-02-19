using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenePanelsControl : PanelsControl
{
    [SerializeField] private Panel choiceMainPointPanel;
    [SerializeField] private Panel choiceOtherPointPanel_1;
    [SerializeField] private Panel choiceOtherPointPanel_2;
    [SerializeField] private Panel firstViewMapPanel;
    [SerializeField] private Panel confirmationRoomSizePanel;
    [SerializeField] private Panel secondViewMapPanel;
    [SerializeField] private Panel menuPanel;

    public override void Initialize()
    {
        base.Initialize();

        menuPanel.Initialize();
        choiceMainPointPanel.Initialize();
        choiceOtherPointPanel_1.Initialize();
        choiceOtherPointPanel_2.Initialize();
        confirmationRoomSizePanel.Initialize();
        firstViewMapPanel.Initialize();
        secondViewMapPanel.Initialize();

        OpenPanel(menuPanel);
    }
}
