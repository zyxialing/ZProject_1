using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
using ZFramework;

namespace Table {
    [Serializable]
    public class excel_character : IConfig
    {
        /// <summary>
        /// 编号150000-159999
        /// </summary>
        [XmlIgnore]
        public int id;
        [XmlAttribute("id")]
        public string _id {
            get { return id.ToString(); }
            set { if (string.IsNullOrEmpty(value)) id = 0; else id = int.Parse(value); }
        }

        /// <summary>
        /// 名字
        /// </summary>
        [XmlIgnore]
        public int name;
        [XmlAttribute("name")]
        public string _name {
            get { return name.ToString(); }
            set { if (string.IsNullOrEmpty(value)) name = 0; else name = int.Parse(value); }
        }

        /// <summary>
        /// 基础血量
        /// </summary>
        [XmlIgnore]
        public int hp;
        [XmlAttribute("hp")]
        public string _hp {
            get { return hp.ToString(); }
            set { if (string.IsNullOrEmpty(value)) hp = 0; else hp = int.Parse(value); }
        }

        /// <summary>
        /// 入战范围
        /// </summary>
        [XmlIgnore]
        public float attackRange;
        [XmlAttribute("attackRange")]
        public string _attackRange {
            get { return attackRange.ToString(); }
            set { if (string.IsNullOrEmpty(value)) attackRange = 0; else attackRange = float.Parse(value); }
        }

        /// <summary>
        /// 路径
        /// </summary>
        [XmlIgnore]
        public string path;
        [XmlAttribute("path")]
        public string _path {
            get { return path.ToString(); }
            set { if (string.IsNullOrEmpty(value)) path = ""; else path = value; }
        }

        public List<T> LoadBytes<T>()
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/excel_character";
             TextAsset asset = TextAssetUtils.GetTextAsset(bytesPath);
            List<T> excel_characters = DeserializeData<T>(asset);
            return excel_characters;
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allexcel_character table = formatter.Deserialize(ms) as allexcel_character;
                Config<excel_character>.AddExcelToDic(typeof(T).Name, table.excel_characters);
                return table.excel_characters  as List<T>;
            }
        }
    }

    [Serializable]
    public class allexcel_character
    {
        public List<excel_character> excel_characters;
    }
}
