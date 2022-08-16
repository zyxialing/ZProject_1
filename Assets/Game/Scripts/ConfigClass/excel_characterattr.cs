using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
using ZFramework;

namespace Table {
    [Serializable]
    public class excel_characterattr : IConfig
    {
        /// <summary>
        /// 编号160000-169999
        /// </summary>
        [XmlIgnore]
        public int id;
        [XmlAttribute("id")]
        public string _id {
            get { return id.ToString(); }
            set { if (string.IsNullOrEmpty(value)) id = 0; else id = int.Parse(value); }
        }

        /// <summary>
        /// 描述，无实际作用
        /// </summary>
        [XmlIgnore]
        public string des;
        [XmlAttribute("des")]
        public string _des {
            get { return des.ToString(); }
            set { if (string.IsNullOrEmpty(value)) des = ""; else des = value; }
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
        /// 攻击频率
        /// </summary>
        [XmlIgnore]
        public float attackFrequency;
        [XmlAttribute("attackFrequency")]
        public string _attackFrequency {
            get { return attackFrequency.ToString(); }
            set { if (string.IsNullOrEmpty(value)) attackFrequency = 0; else attackFrequency = float.Parse(value); }
        }

        /// <summary>
        /// 是否有暴击动画
        /// </summary>
        [XmlIgnore]
        public bool criticalHitAnim;
        [XmlAttribute("criticalHitAnim")]
        public string _criticalHitAnim {
            get { return criticalHitAnim.ToString(); }
            set { if (string.IsNullOrEmpty(value)) criticalHitAnim = false; else criticalHitAnim = bool.Parse(value); }
        }

        /// <summary>
        /// 攻击伤害触发点
        /// </summary>
        [XmlIgnore]
        public float attackProgressBack;
        [XmlAttribute("attackProgressBack")]
        public string _attackProgressBack {
            get { return attackProgressBack.ToString(); }
            set { if (string.IsNullOrEmpty(value)) attackProgressBack = 0; else attackProgressBack = float.Parse(value); }
        }

        /// <summary>
        /// 己方ai路径
        /// </summary>
        [XmlIgnore]
        public string heroPath;
        [XmlAttribute("heroPath")]
        public string _heroPath {
            get { return heroPath.ToString(); }
            set { if (string.IsNullOrEmpty(value)) heroPath = ""; else heroPath = value; }
        }

        /// <summary>
        /// 敌方ai路径
        /// </summary>
        [XmlIgnore]
        public string enemyPath;
        [XmlAttribute("enemyPath")]
        public string _enemyPath {
            get { return enemyPath.ToString(); }
            set { if (string.IsNullOrEmpty(value)) enemyPath = ""; else enemyPath = value; }
        }

        public List<T> LoadBytes<T>()
        {
            string bytesPath = "Assets/Game/AssetDynamic/ConfigBytes/excel_characterattr";
             TextAsset asset = TextAssetUtils.GetTextAsset(bytesPath);
            List<T> excel_characterattrs = DeserializeData<T>(asset);
            return excel_characterattrs;
        }

         private List<T> DeserializeData<T>(UnityEngine.TextAsset textAsset)
        {
            using (MemoryStream ms = new MemoryStream(textAsset.bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                allexcel_characterattr table = formatter.Deserialize(ms) as allexcel_characterattr;
                Config<excel_characterattr>.AddExcelToDic(typeof(T).Name, table.excel_characterattrs);
                return table.excel_characterattrs  as List<T>;
            }
        }
    }

    [Serializable]
    public class allexcel_characterattr
    {
        public List<excel_characterattr> excel_characterattrs;
    }
}
