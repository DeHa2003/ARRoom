using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceThirdPointPanel : Panel
{
    [SerializeField] private SpawnThirdPoint thirdPoint;
    public override void Initialize()
    {
        base.Initialize();
        thirdPoint.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        thirdPoint.ActivateSpawn();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        thirdPoint.DiactivateSpawn();
    }
}
