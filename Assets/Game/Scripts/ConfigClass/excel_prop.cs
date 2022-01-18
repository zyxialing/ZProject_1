using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using ZFramework;

namespace Table {
    [Serializable]
    public class excel_prop : IConfig
    {
        /// <summary>
        /// 编号200000-219999
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

        public void LoadBytes<T>(Action<List<T>> callBack)
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/excel_prop";
            TextAssetUtils.SafeGetTextAsset(bytesPath, (asset) =>
            {
                List<T> excel_props = DeserializeData<T>(asset);
                callBack?.Invoke(excel_props);
            });
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allexcel_prop table = formatter.Deserialize(ms) as allexcel_prop;
                Config<excel_prop>.AddExcelToDic(typeof(T).Name, table.excel_props);
                return table.excel_props  as List<T>;
            }
        }
    }

    [Serializable]
    public class allexcel_prop
    {
        public List<excel_prop> excel_props;
    }
}
