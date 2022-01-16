using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

    [Serializable]
    public class equip : IConfig
    {
        /// <summary>
        /// 编号
        /// </summary>
        [XmlAttribute("id")]
        public int id;

        /// <summary>
        /// 名字（多语言id）
        /// </summary>
        [XmlAttribute("name")]
        public int name;

        /// <summary>
        /// 图片路径（adressable）
        /// </summary>
        [XmlAttribute("icon")]
        public string icon;

        /// <summary>
        /// 描述(多语言id)
        /// </summary>
        [XmlAttribute("desc")]
        public int desc;

        public void LoadBytes<T>(Action<List<T>> callBack)
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/equip";
            TextAssetUtils.SafeGetTextAsset(bytesPath, (asset) =>
            {
                List<T> equips = DeserializeData<T>(asset);
                callBack?.Invoke(equips);
            });
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allequip table = formatter.Deserialize(ms) as allequip;
                Config<equip>.AddExcelToDic(typeof(T).Name, table.equips);
                return table.equips as List<T>;
            }
        }
    }

    [Serializable]
    public class allequip
    {
        public List<equip> equips;
    }
