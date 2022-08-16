using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Table;

public class LevelMgr : ILevelMgr
{
    List<LevelData> levelList;
    Dictionary<int, LevelData> levelMap;
    public LevelMgr()
    {
        levelList = new List<LevelData>();
        levelMap = new Dictionary<int, LevelData>();
        List<excel_level> list = ExcelConfig.Instance.GetExcelData().excel_levelList;
        for (int i = 0; i < list.Count; i++)
        {
            LevelData levelData = new LevelData(list[i].id, list[i].order);
            levelList.Add(levelData);
            levelMap.Add(list[i].id,levelData);
        }
        ZLogUtil.Log(levelList.Count);
    }

    public List<LevelData> GetAllLevelData()
    {
        return levelList;
    }
}
