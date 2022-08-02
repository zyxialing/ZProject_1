using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 战斗中，游戏的产生的数据统计
/// </summary>
public class Statistics : Singleton<Statistics>
{
    private int battle_Stage;    /// 游戏阶段

    private Statistics()
    {
        Clear();
    }

    public int GetBattleStage()
    {
        return battle_Stage;
    }

    public void SetBattleStage(int num=1)
    {
        battle_Stage += num;
        ZLogUtil.LogError("游戏阶段" + battle_Stage);
    }




    public void Clear()
    {
        battle_Stage = 0;
    }
}
