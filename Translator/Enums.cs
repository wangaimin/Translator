using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    /// <summary>
    /// 翻译工具
    /// </summary>
    public enum TranslationMethods {
        Bing,
        YouDao,
        Google
    }

    /// <summary>
    /// 翻译类别
    /// </summary>
    public enum TranslationCategory {
        Config,
        JSON
    }
}
