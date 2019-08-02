using System;
using I18nLib;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            I18nLanguageRes i18n = new I18nLanguageRes("Chinese", "English", "Japanese");
            i18n.AddItem("Greeting", "你好", "Hello", null);
            i18n.SetLocale("Chinese");
            Console.WriteLine(i18n["Greeting"]);
            i18n.SetLocale("English");
            Console.WriteLine(i18n["Greeting"]);
            i18n.SetLocale("Japanese");
            Console.WriteLine(i18n["Greeting"]);
        }
    }
}
