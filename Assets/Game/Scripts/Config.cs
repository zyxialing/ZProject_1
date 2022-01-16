using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config<T> where T :IConfig
{
    private static Dictionary<string, List<T>> excelDatas = new Dictionary<string, List<T>>();
    public static void InitConfig(Action<List<T>> callBack)
    {
        T t = Activator.CreateInstance<T>();
        t.LoadBytes(callBack);
    }

    public static void AddExcelToDic(string name,List<T> excelData)
    {
        if (!excelDatas.ContainsKey(name))
        {
            excelDatas.Add(name, excelData);
        }
    }

    public static List<T> GetExcel()
    {
        string name = typeof(T).Name;
        if (excelDatas.ContainsKey(name))
        {
            return excelDatas[name];
        }
        return null;
    }
}
