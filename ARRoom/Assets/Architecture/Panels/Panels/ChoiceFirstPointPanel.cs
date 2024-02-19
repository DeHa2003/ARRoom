using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceFirstPointPanel : MovePanel
{
    [SerializeField] private SpawnMainPoint spawnPoint;
    public override void Initialize()
    {
        base.Initialize();
        spawnPoint.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        spawnPoint.ActivateSpawn();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        spawnPoint.DiactivateSpawn();
    }

}
