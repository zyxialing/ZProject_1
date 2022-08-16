//脚本自动生成，不要进行修改
using System.Collections.Generic;
using UnityEngine;
using Table;

public class ExcelConfig : Singleton<ExcelConfig>
{
    ExcelData excelData = new ExcelData();
    private ExcelConfig()
    {
    }

    public ExcelData GetExcelData()
    {
        return excelData;
    }

    public void InitExcelData<T>(List<T> list)
    {
        excelData.InitData(list);
    }

    public void LoadAllExcel()
    {
        ExcelLoader excelLoader = new GameObject("ExcelLoader").AddComponent<ExcelLoader>();
        excelLoader.LoadExcel();
    }

    #region 外部调用
    public static excel_affix Get_excel_affix(int id)    {
      return  Instance.GetExcelData().excel_affixMap[id];
    }
    public static excel_birthtype Get_excel_birthtype(int id)    {
      return  Instance.GetExcelData().excel_birthtypeMap[id];
    }
    public static excel_character Get_excel_character(int id)    {
      return  Instance.GetExcelData().excel_characterMap[id];
    }
    public static excel_characterattr Get_excel_characterattr(int id)    {
      return  Instance.GetExcelData().excel_characterattrMap[id];
    }
    public static excel_equip Get_excel_equip(int id)    {
      return  Instance.GetExcelData().excel_equipMap[id];
    }
    public static excel_language Get_excel_language(int id)    {
      return  Instance.GetExcelData().excel_languageMap[id];
    }
    public static excel_level Get_excel_level(int id)    {
      return  Instance.GetExcelData().excel_levelMap[id];
    }
    public static excel_material Get_excel_material(int id)    {
      return  Instance.GetExcelData().excel_materialMap[id];
    }
    public static excel_prop Get_excel_prop(int id)    {
      return  Instance.GetExcelData().excel_propMap[id];
    }
    #endregion
}