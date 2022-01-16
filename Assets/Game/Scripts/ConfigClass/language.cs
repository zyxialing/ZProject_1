using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

    [Serializable]
    public class language : IConfig
    {
        /// <summary>
        /// 编号
        /// </summary>
        [XmlAttribute("id")]
        public int id;

        /// <summary>
        /// 中文
        /// </summary>
        [XmlAttribute("ch")]
        public string ch;

        /// <summary>
        /// 英文
        /// </summary>
        [XmlAttribute("en")]
        public string en;

        /// <summary>
        /// 日语
        /// </summary>
        [XmlAttribute("js")]
        public string js;

        public void LoadBytes<T>(Action<List<T>> callBack)
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/language";
            TextAssetUtils.SafeGetTextAsset(bytesPath, (asset) =>
            {
                List<T> languages = DeserializeData<T>(asset);
                callBack?.Invoke(languages);
            });
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                alllanguage table = formatter.Deserialize(ms) as alllanguage;
                return table.languages  as List<T>;
            }
        }
    }

    [Serializable]
    public class alllanguage
    {
        public List<language> languages;
    }
