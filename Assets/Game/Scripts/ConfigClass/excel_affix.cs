using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using ZFramework;

namespace Table {
    [Serializable]
    public class excel_affix : IConfig
    {
        /// <summary>
        /// 编号100000-129999
        /// </summary>
        [XmlIgnore]
        public int id;
        [XmlAttribute("id")]
        public string _id {
            get { return id.ToString(); }
            set { if (string.IsNullOrEmpty(value)) id = 0; else id = int.Parse(value); }
        }

        /// <summary>
        /// 名字（多语言id）
        /// </summary>
        [XmlIgnore]
        public int name;
        [XmlAttribute("name")]
        public string _name {
            get { return name.ToString(); }
            set { if (string.IsNullOrEmpty(value)) name = 0; else name = int.Parse(value); }
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
        /// 描述(多语言id)
        /// </summary>
        [XmlIgnore]
        public int desc;
        [XmlAttribute("desc")]
        public string _desc {
            get { return desc.ToString(); }
            set { if (string.IsNullOrEmpty(value)) desc = 0; else desc = int.Parse(value); }
        }

        public void LoadBytes<T>(Action<List<T>> callBack)
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/excel_affix";
            TextAssetUtils.SafeGetTextAsset(bytesPath, (asset) =>
            {
                List<T> excel_affixs = DeserializeData<T>(asset);
                callBack?.Invoke(excel_affixs);
            });
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allexcel_affix table = formatter.Deserialize(ms) as allexcel_affix;
                Config<excel_affix>.AddExcelToDic(typeof(T).Name, table.excel_affixs);
                return table.excel_affixs  as List<T>;
            }
        }
    }

    [Serializable]
    public class allexcel_affix
    {
        public List<excel_affix> excel_affixs;
    }
}
