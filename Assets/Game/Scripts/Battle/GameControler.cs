using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : Singleton<GameControler>
{
    Camera _sceneCamera;
    private GameControler()
    {

    }
    public void Init()
    {
        _sceneCamera = CameraUtils.CreateCamer("SceneCamera");
        CameraUtils.SetSceneCameraParma(_sceneCamera);
    }
}
