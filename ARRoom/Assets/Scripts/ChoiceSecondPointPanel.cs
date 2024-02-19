using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceSecondPointPanel : MovePanel
{
    [SerializeField] private SpawnSecondPoint secondPoint;
    public override void Initialize()
    {
        base.Initialize();
        secondPoint.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        secondPoint.ActivateSpawn();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        secondPoint.DiactivateSpawn();
    }
}
