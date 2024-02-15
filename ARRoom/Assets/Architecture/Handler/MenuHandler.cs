using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : Handler
{
    [SerializeField] private MenuInputData inputData;
    protected override void Awake()
    {
        Game.Run(new StartSceneManager());
        base.Awake();
    }

    protected override void OnGameInitialized()
    {
        inputData.Initialize();
        base.OnGameInitialized();
    }
}
