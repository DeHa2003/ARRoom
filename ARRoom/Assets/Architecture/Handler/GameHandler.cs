using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : Handler
{
    [SerializeField] private GlobalEvents_GameScene events_GameScene;
    [SerializeField] private GameInputData inputData;
    protected override void Awake()
    {
        Game.Run(new MainSceneManager());
        base.Awake();
    }

    protected override void OnGameInitialized()
    {
        inputData.Initialize();
        events_GameScene.Initialize();
        base.OnGameInitialized();
    }
}
