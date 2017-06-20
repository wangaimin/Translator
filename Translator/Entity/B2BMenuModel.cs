using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Translator
{
    [Serializable]
    public class B2BMenuModel
    {
        public B2BMenuModel()
        {
        }

        [XmlAttribute]
        public string MenuType { get; set; }

        [XmlAttribute]
        public string MenuName { get; set; }

        [XmlAttribute]
        public string ShortName { get; set; }

        [XmlAttribute]
        public string SysNo { get; set; }

        [XmlAttribute]
        public string ParentSysNo { get; set; }

        [XmlAttribute]
        public string IsDisplay { get; set; }

        private string _LinkPath;
        [XmlAttribute]
        public string LinkPath
        {
            get
            {
                return _LinkPath;
            }
            set
            {
                    _LinkPath = value;
            }
        }

        [XmlAttribute]
        public string MenuDomain { get; set; }

        [XmlAttribute]
        public int UserType { get; set; }

        [XmlAttribute]
        public string AuthKey { get; set; }

        [XmlAttribute]
        public string IconFont { get; set; }

        /// <summary>
        /// 是否是优选显示
        /// </summary>
        [XmlAttribute]
        public string IsChoiceDisplay { get; set; }

        public bool IsShow()
        {
            return string.Compare(IsDisplay, "True", true) == 0
                    || string.Compare(IsDisplay, "1", true) == 0
                    || string.Compare(IsDisplay, "Yes", true) == 0;
        }




      
    }
}
