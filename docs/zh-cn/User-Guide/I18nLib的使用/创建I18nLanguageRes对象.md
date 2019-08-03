# 创建I18nLanguageRes对象

I18nLanguageRes 对象是 I18nLib 库中的主要 API，通过创建这个对象便可使用 I18nLib 提供的多语言支持。首先，确定你要支持的语言，
将语言名称放入一个 string[]内，如下所示： 
<code>string[] languageList={“lang1”,”lang2”,”lang3”}; </code>
其中 lang1，lang2，lang3 为你想要支持的语言，这样的语言可以有无数个。然后我们添加如下一行来创建 I18nLanguageRes 对象： 
<code>  I18nLanguageRes i18n=new I18nLanguageRes(languageList); </code>
languageList 即为您创建的 string[]名称 
