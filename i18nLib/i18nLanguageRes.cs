using System;
using System.Collections.Generic;
using System.Text;

namespace I18nLib
{
    /// <summary>
    /// 该类提供了一个多语言数据库，对应用中的文本信息进行硬编码，从而得到应用国际化的效果
    /// </summary>
    public sealed class I18nLanguageRes
    {
        /// <summary>
        /// 语言文本储存于此，Dictionary数据结构中的键相当于该数据库中的主键，值为对应的值
        /// </summary>
        private Dictionary<string, string[]> dataDict;
        /// <summary>
        /// 指定使用什么语言（locale）
        /// </summary>
        private int? localeIndex;
        /// <summary>
        /// 语言的名称，初始化后可用此名称来指定使用什么语言
        /// </summary>
        private string[] langName;
        /// <summary>
        /// 可用的语言的个数
        /// </summary>
        private int dictSize;

        /// <summary>
        /// I18nLanguageRes的构造函数
        /// </summary>
        /// <param name="supportLang">支持的语言列表</param>
        public I18nLanguageRes(params string[] supportLang)
        {
            langName = supportLang;
            dictSize = langName.Length;
            localeIndex = null;
            dataDict = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// 添加一项文本资源
        /// </summary>
        /// <param name="pair">添加的项，其中Value的元素个数需要与可支持的语言个数相同，若有某一种语言版本暂不支持，则可将此元素设置为null</param>
        /// <exception cref="FormatException">当提供的Value元素个数与支持的语言个数不一致时抛出该异常</exception>
        /// <returns>返回提供的键</returns>
        public string AddItem(KeyValuePair<string, string[]> pair)
        {
            if (pair.Value.Length != dictSize)
            {
                throw new FormatException("The length of the pair's value must be " + dictSize);
            }
            dataDict.Add(pair.Key, pair.Value);
            return pair.Key;
        }

        public string AddItem(string key, params string[] value)
        {
            return AddItem(new KeyValuePair<string, string[]>(key, value));
        }

        /// <summary>
        /// 设置语言
        /// </summary>
        /// <param name="lang">语言名称</param>
        /// <returns>语言名称</returns>
        public string SetLocale(string lang)
        {
            if (Array.IndexOf(langName,lang)==-1)
                throw new ArgumentException("There are no supported language named " + lang);
            localeIndex = Array.IndexOf(langName, lang);
            return lang;
        }

        /// <summary>
        /// 获取当前语言的名称
        /// </summary>
        /// <exception cref="ArgumentNullException">当尚未设置当前语言时抛出</exception>
        /// <returns>当前语言</returns>
        public string GetCurrentLocale()
        {
            if (localeIndex == null)
                throw new ArgumentNullException("Undefined current language");
            return langName[(int)localeIndex];
        }

        /// <summary>
        /// 获取指定的文本名称所对应的文本（现已不支持使用，请使用索引器）
        /// </summary>
        /// <param name="textName">文本名称</param>
        /// <returns>文本</returns>
        public string GetText(string textName)
        {
            if (dataDict[textName][(int)localeIndex] != null)
            {
                return dataDict[textName][(int)localeIndex];
            }
            else
                foreach (string s in dataDict[textName])
                {
                    if (s != null)
                        return s;
                }
            throw new ArgumentOutOfRangeException("All of the elements in "+textName+" are null");
        }

        public string this[string textName]
        {
            get
            {
                return GetText(textName);
            }
        }

    }
}
