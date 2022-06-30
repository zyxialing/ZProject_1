//脚本自动生成，不要进行修改
using System.Collections.Generic;
using Table;

public class ExcelData
{
    public Dictionary<int, excel_affix> excel_affixMap = new Dictionary<int, excel_affix>();
    public List<excel_affix> excel_affixList = new List<excel_affix>();
    public Dictionary<int, excel_character> excel_characterMap = new Dictionary<int, excel_character>();
    public List<excel_character> excel_characterList = new List<excel_character>();
    public Dictionary<int, excel_equip> excel_equipMap = new Dictionary<int, excel_equip>();
    public List<excel_equip> excel_equipList = new List<excel_equip>();
    public Dictionary<int, excel_language> excel_languageMap = new Dictionary<int, excel_language>();
    public List<excel_language> excel_languageList = new List<excel_language>();
    public Dictionary<int, excel_material> excel_materialMap = new Dictionary<int, excel_material>();
    public List<excel_material> excel_materialList = new List<excel_material>();
    public Dictionary<int, excel_prop> excel_propMap = new Dictionary<int, excel_prop>();
    public List<excel_prop> excel_propList = new List<excel_prop>();

    public void InitData<T>(List<T> list)
    {
        switch (typeof(T).Name)
        {
            case "excel_affix":
                excel_affixList = list as List<excel_affix>;
                for (int i = 0; i < excel_affixList.Count; i++)
                {
                    excel_affixMap.Add(excel_affixList[i].id, excel_affixList[i]);
                }
                break;
            case "excel_character":
                excel_characterList = list as List<excel_character>;
                for (int i = 0; i < excel_characterList.Count; i++)
                {
                    excel_characterMap.Add(excel_characterList[i].id, excel_characterList[i]);
                }
                break;
            case "excel_equip":
                excel_equipList = list as List<excel_equip>;
                for (int i = 0; i < excel_equipList.Count; i++)
                {
                    excel_equipMap.Add(excel_equipList[i].id, excel_equipList[i]);
                }
                break;
            case "excel_language":
                excel_languageList = list as List<excel_language>;
                for (int i = 0; i < excel_languageList.Count; i++)
                {
                    excel_languageMap.Add(excel_languageList[i].id, excel_languageList[i]);
                }
                break;
            case "excel_material":
                excel_materialList = list as List<excel_material>;
                for (int i = 0; i < excel_materialList.Count; i++)
                {
                    excel_materialMap.Add(excel_materialList[i].id, excel_materialList[i]);
                }
                break;
            case "excel_prop":
                excel_propList = list as List<excel_prop>;
                for (int i = 0; i < excel_propList.Count; i++)
                {
                    excel_propMap.Add(excel_propList[i].id, excel_propList[i]);
                }
                break;
        }
    }
}
