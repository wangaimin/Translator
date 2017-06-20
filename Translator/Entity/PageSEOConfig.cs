using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Translator
{
    [Serializable]
    public class PageSEOConfig
    {
        public PageSEOConfig()
        {
            this.CustomList = new List<PageSEODetail>();
        }

        [XmlArray]
        public List<PageSEODetail> CustomList { get; set; }

        [XmlElement]
        public string SuffixTitle { get; set; }
    }

    public class PageSEODetail
    {
        [XmlAttribute]
        public string Area { get; set; }

        [XmlAttribute]
        public string Controller { get; set; }

        [XmlAttribute]
        public string Action { get; set; }

        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Keywords { get; set; }

        [XmlAttribute]
        public string Description { get; set; }
    }
}
