using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
using ZFramework;

namespace Table {
    [Serializable]
    public class excel_equip : IConfig
    {
        /// <summary>
        /// 编号
        ///130000-139999
        /// </summary>
        [XmlIgnore]
        public int id;
        [XmlAttribute("id")]
        public string _id {
            get { return id.ToString(); }
            set { if (string.IsNullOrEmpty(value)) id = 0; else id = int.Parse(value); }
        }

        /// <summary>
        /// 名字（多语言id10000-99999
        /// </summary>
        [XmlIgnore]
        public int name;
        [XmlAttribute("name")]
        public string _name {
            get { return name.ToString(); }
            set { if (string.IsNullOrEmpty(value)) name = 0; else name = int.Parse(value); }
        }

        /// <summary>
        /// 武器种类（对应游戏枚举（1-？？））
        /// </summary>
        [XmlIgnore]
        public int type;
        [XmlAttribute("type")]
        public string _type {
            get { return type.ToString(); }
            set { if (string.IsNullOrEmpty(value)) type = 0; else type = int.Parse(value); }
        }

        /// <summary>
        /// 图片路径（adressable）
        /// </summary>
        [XmlIgnore]
        public string icon;
        [XmlAttribute("icon")]
        public string _icon {
            get { return icon.ToString(); }
            set { if (string.IsNullOrEmpty(value)) icon = ""; else icon = value; }
        }

        /// <summary>
        /// 描述(多语言id)10000-99999
        /// </summary>
        [XmlIgnore]
        public int desc;
        [XmlAttribute("desc")]
        public string _desc {
            get { return desc.ToString(); }
            set { if (string.IsNullOrEmpty(value)) desc = 0; else desc = int.Parse(value); }
        }

        /// <summary>
        /// 词缀id100000-129999
        /// </summary>
        [XmlIgnore]
        public List<int> attr;
        [XmlAttribute("attr")]
        public string _attr {
            get { return attr.ToString(); }
            set{ if (string.IsNullOrEmpty(value)) attr = new List<int>();else attr = ZStringUtil.ArrayStringToIntList(value.Split('-'));}
        }

        /// <summary>
        /// 携带技能140000-149999
        /// </summary>
        [XmlIgnore]
        public List<int> skill;
        [XmlAttribute("skill")]
        public string _skill {
            get { return skill.ToString(); }
            set{ if (string.IsNullOrEmpty(value)) skill = new List<int>();else skill = ZStringUtil.ArrayStringToIntList(value.Split('-'));}
        }

        public List<T> LoadBytes<T>()
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/excel_equip";
             TextAsset asset = TextAssetUtils.GetTextAsset(bytesPath);
            List<T> excel_equips = DeserializeData<T>(asset);
            return excel_equips;
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allexcel_equip table = formatter.Deserialize(ms) as allexcel_equip;
                Config<excel_equip>.AddExcelToDic(typeof(T).Name, table.excel_equips);
                return table.excel_equips  as List<T>;
            }
        }
    }

    [Serializable]
    public class allexcel_equip
    {
        public List<excel_equip> excel_equips;
    }
}
