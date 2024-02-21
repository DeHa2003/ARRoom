using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "MainScene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<NotificationInteractor>(interactorsMap);
        CreateInteractor<PanelAnimationInteractor>(interactorsMap);
        CreateInteractor<RoomInteractor>(interactorsMap);
        CreateInteractor<PointInPlaneDetectionInteractor>(interactorsMap);
        CreateInteractor<TimerInteractor>(interactorsMap);
        CreateInteractor<HitItemsInteractor>(interactorsMap);
        CreateInteractor<HealthInteractor>(interactorsMap);
        CreateInteractor<ScoreInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<ScoreRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
