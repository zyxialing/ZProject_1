using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
using ZFramework;

namespace Table {
    [Serializable]
    public class excel_level : IConfig
    {
        /// <summary>
        /// 编号240000-269999
        /// </summary>
        [XmlIgnore]
        public int id;
        [XmlAttribute("id")]
        public string _id {
            get { return id.ToString(); }
            set { if (string.IsNullOrEmpty(value)) id = 0; else id = int.Parse(value); }
        }

        /// <summary>
        /// 关卡
        /// </summary>
        [XmlIgnore]
        public int order;
        [XmlAttribute("order")]
        public string _order {
            get { return order.ToString(); }
            set { if (string.IsNullOrEmpty(value)) order = 0; else order = int.Parse(value); }
        }

        /// <summary>
        /// （怪物出生类型）
        /// </summary>
        [XmlIgnore]
        public int birthType;
        [XmlAttribute("birthType")]
        public string _birthType {
            get { return birthType.ToString(); }
            set { if (string.IsNullOrEmpty(value)) birthType = 0; else birthType = int.Parse(value); }
        }

        public List<T> LoadBytes<T>()
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/excel_level";
             TextAsset asset = TextAssetUtils.GetTextAsset(bytesPath);
            List<T> excel_levels = DeserializeData<T>(asset);
            return excel_levels;
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allexcel_level table = formatter.Deserialize(ms) as allexcel_level;
                Config<excel_level>.AddExcelToDic(typeof(T).Name, table.excel_levels);
                return table.excel_levels  as List<T>;
            }
        }
    }

    [Serializable]
    public class allexcel_level
    {
        public List<excel_level> excel_levels;
    }
}
