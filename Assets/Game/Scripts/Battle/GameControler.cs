using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class GameControler : Singleton<GameControler>
{
    private GameControler()
    {

    }

    public void GoLevelScene(Action callBack = null)
    {
        ResLoader.Instance.GetScene("EmptyScene", (hander) =>
        {
            callBack?.Invoke();
            Clear();
            JumpManager.GomeHome(() => { JumpManager.JumpPanel<LevelPanel>(); });

        });
    }

    public void GoGameScene(Action callBack = null)
    {
        ResLoader.Instance.GetScene("GameScene", (hander) =>
        {
            callBack?.Invoke();
            JumpManager.JumpPanel<MainPanel>();
        });
    }

    public void Clear()
    {
        Timer.CancelAllRegisteredTimers();
        ZGameObjectPool.ClearPools();
    }
}
