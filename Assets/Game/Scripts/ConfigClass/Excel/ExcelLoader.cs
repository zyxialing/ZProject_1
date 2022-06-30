//脚本自动生成，不要进行修改
using UnityEngine;
using Table;

public class ExcelLoader : MonoBehaviour
{
    public void LoadExcel()
    {
        ExcelConfig.Instance.InitExcelData(Config<excel_affix>.InitConfig());
        ExcelConfig.Instance.InitExcelData(Config<excel_character>.InitConfig());
        ExcelConfig.Instance.InitExcelData(Config<excel_equip>.InitConfig());
        ExcelConfig.Instance.InitExcelData(Config<excel_language>.InitConfig());
        ExcelConfig.Instance.InitExcelData(Config<excel_material>.InitConfig());
        ExcelConfig.Instance.InitExcelData(Config<excel_prop>.InitConfig());
    }
}
