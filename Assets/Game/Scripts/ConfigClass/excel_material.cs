using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
using ZFramework;

namespace Table {
    [Serializable]
    public class excel_material : IConfig
    {
        /// <summary>
        /// 编号220000-239999
        /// </summary>
        [XmlIgnore]
        public int id;
        [XmlAttribute("id")]
        public string _id {
            get { return id.ToString(); }
            set { if (string.IsNullOrEmpty(value)) id = 0; else id = int.Parse(value); }
        }

        /// <summary>
        /// 中文
        /// </summary>
        [XmlIgnore]
        public string ch;
        [XmlAttribute("ch")]
        public string _ch {
            get { return ch.ToString(); }
            set { if (string.IsNullOrEmpty(value)) ch = ""; else ch = value; }
        }

        /// <summary>
        /// 英文
        /// </summary>
        [XmlIgnore]
        public string en;
        [XmlAttribute("en")]
        public string _en {
            get { return en.ToString(); }
            set { if (string.IsNullOrEmpty(value)) en = ""; else en = value; }
        }

        /// <summary>
        /// 日语
        /// </summary>
        [XmlIgnore]
        public string js;
        [XmlAttribute("js")]
        public string _js {
            get { return js.ToString(); }
            set { if (string.IsNullOrEmpty(value)) js = ""; else js = value; }
        }

        public List<T> LoadBytes<T>()
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/excel_material";
             TextAsset asset = TextAssetUtils.GetTextAsset(bytesPath);
            List<T> excel_materials = DeserializeData<T>(asset);
            return excel_materials;
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allexcel_material table = formatter.Deserialize(ms) as allexcel_material;
                Config<excel_material>.AddExcelToDic(typeof(T).Name, table.excel_materials);
                return table.excel_materials  as List<T>;
            }
        }
    }

    [Serializable]
    public class allexcel_material
    {
        public List<excel_material> excel_materials;
    }
}
