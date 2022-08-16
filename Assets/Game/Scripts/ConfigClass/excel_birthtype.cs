using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
using ZFramework;

namespace Table {
    [Serializable]
    public class excel_birthtype : IConfig
    {
        /// <summary>
        /// 编号250000-250999
        /// </summary>
        [XmlIgnore]
        public int id;
        [XmlAttribute("id")]
        public string _id {
            get { return id.ToString(); }
            set { if (string.IsNullOrEmpty(value)) id = 0; else id = int.Parse(value); }
        }

        /// <summary>
        /// 介绍
        /// </summary>
        [XmlIgnore]
        public string des;
        [XmlAttribute("des")]
        public string _des {
            get { return des.ToString(); }
            set { if (string.IsNullOrEmpty(value)) des = ""; else des = value; }
        }

        /// <summary>
        /// 最大阶段
        /// </summary>
        [XmlIgnore]
        public int maxStage;
        [XmlAttribute("maxStage")]
        public string _maxStage {
            get { return maxStage.ToString(); }
            set { if (string.IsNullOrEmpty(value)) maxStage = 0; else maxStage = int.Parse(value); }
        }

        /// <summary>
        /// 阶段出怪
        /// </summary>
        [XmlIgnore]
        public List<int> stageMonster;
        [XmlAttribute("stageMonster")]
        public string _stageMonster {
            get { return stageMonster.ToString(); }
            set{ if (string.IsNullOrEmpty(value)) stageMonster = new List<int>();else stageMonster = ZStringUtil.ArrayStringToIntList(value.Split('-'));}
        }

        public List<T> LoadBytes<T>()
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/excel_birthtype";
             TextAsset asset = TextAssetUtils.GetTextAsset(bytesPath);
            List<T> excel_birthtypes = DeserializeData<T>(asset);
            return excel_birthtypes;
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allexcel_birthtype table = formatter.Deserialize(ms) as allexcel_birthtype;
                Config<excel_birthtype>.AddExcelToDic(typeof(T).Name, table.excel_birthtypes);
                return table.excel_birthtypes  as List<T>;
            }
        }
    }

    [Serializable]
    public class allexcel_birthtype
    {
        public List<excel_birthtype> excel_birthtypes;
    }
}
