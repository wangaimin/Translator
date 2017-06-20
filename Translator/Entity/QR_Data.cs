using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    #region bing
    public class BingResultData
    {

        public string from { get; set; }
        public string to { get; set; }

        public List<BingItemData> items { get; set; }

    }


    public class BingItemData
    {
        public string id { get; set; }
        public string text { get; set; }

        public string wordAlignment { get; set; }
    }
    #endregion




    #region YouDao

    public class YouDaoResultData
    {
        public YouDaoResultData(){
            translation=new List<string>();
            web = new List<Web>();
    }

        public int errorCode { get; set; }
        /// <summary>
        /// 发音地址（有些翻译结果没有）
        /// </summary>
       /// public string tSpeakUrl { get; set; }

        public string query { get; set; }

        public List<string> translation { get; set; }

        /// <summary>
        /// 当translation没值的时候取web中value中的值
        /// </summary>
        public List<Web> web { get; set; }

    }


    public class Web {
        public List<string> value { get; set; }

        public string key { get; set; }

    }
   
    #endregion

    #region Google

    #endregion
}
