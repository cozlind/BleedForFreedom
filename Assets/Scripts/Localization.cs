using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Localization
{

    public const string LANGUAGE_ENGLISH = "EN";
    public const string LANGUAGE_CHINESE = "CN";
    public const string LANGUAGE_CHINESETR = "TW";
    public const string LANGUAGE_JAPANESE = "JP";

    private const string KEY_CODE = "KEY";
    private const string FILE_PATH = "Localization/localization";

    private SystemLanguage language;
    private Dictionary<string, string> textData = new Dictionary<string, string>();

    private static Localization mInstance;

    private Localization()
    {
    }

    private static string GetLanguageAB(SystemLanguage language)
    {
        switch (language)
        {
            case SystemLanguage.Afrikaans:
            case SystemLanguage.Arabic:
            case SystemLanguage.Basque:
            case SystemLanguage.Belarusian:
            case SystemLanguage.Bulgarian:
            case SystemLanguage.Catalan:
                return LANGUAGE_ENGLISH;
            case SystemLanguage.Chinese:
            case SystemLanguage.ChineseSimplified:
                return LANGUAGE_CHINESE;
            case SystemLanguage.ChineseTraditional:
                return LANGUAGE_CHINESETR;
            case SystemLanguage.Czech:
            case SystemLanguage.Danish:
            case SystemLanguage.Dutch:
            case SystemLanguage.English:
            case SystemLanguage.Estonian:
            case SystemLanguage.Faroese:
            case SystemLanguage.Finnish:
            case SystemLanguage.French:
            case SystemLanguage.German:
            case SystemLanguage.Greek:
            case SystemLanguage.Hebrew:
            case SystemLanguage.Icelandic:
            case SystemLanguage.Indonesian:
            case SystemLanguage.Italian:
                return LANGUAGE_ENGLISH;
            case SystemLanguage.Japanese:
                return LANGUAGE_JAPANESE;
            case SystemLanguage.Korean:
            case SystemLanguage.Latvian:
            case SystemLanguage.Lithuanian:
            case SystemLanguage.Norwegian:
            case SystemLanguage.Polish:
            case SystemLanguage.Portuguese:
            case SystemLanguage.Romanian:
            case SystemLanguage.Russian:
            case SystemLanguage.SerboCroatian:
            case SystemLanguage.Slovak:
            case SystemLanguage.Slovenian:
            case SystemLanguage.Spanish:
            case SystemLanguage.Swedish:
            case SystemLanguage.Thai:
            case SystemLanguage.Turkish:
            case SystemLanguage.Ukrainian:
            case SystemLanguage.Vietnamese:
            case SystemLanguage.Unknown:
                return LANGUAGE_ENGLISH;
        }
        return LANGUAGE_ENGLISH;
    }

    private void ReadData()
    {
        textData.Clear();
        string csvStr = ((TextAsset)Resources.Load(FILE_PATH, typeof(TextAsset))).text;
        CSVLoader loader = new CSVLoader();
        // loader.ReadFile(fileName);
        loader.ReadMultiLine(csvStr);
        int languageIndex = loader.GetFirstIndexAtRow(GetLanguageAB(language), 0);
        if (-1 == languageIndex)
        {
            Debug.LogError("未读取到" + language + "任何数据，请检查配置表");
            return;
        }
        int tempRow = loader.GetRow();
        for (int i = 0; i < tempRow; ++i)
        {
            textData.Add(loader.GetValueAt(0, i), loader.GetValueAt(languageIndex, i));
        }
    }

    private void SetLanguage(SystemLanguage language)
    {
        PlayerPrefs.SetInt("language", (int)language);
        this.language = language;
    }

    public static void Init()
    {
        mInstance = new Localization();
        mInstance.SetLanguage((SystemLanguage)PlayerPrefs.GetInt("language", (int)SystemLanguage.English));
        mInstance.ReadData();
    }


    public static void ManualSetLanguage(SystemLanguage setLanguage)
    {
        if (null == mInstance)
        {
            mInstance = new Localization();
        }
        mInstance.SetLanguage(setLanguage);
        mInstance.ReadData();
    }

    public static string GetText(string key)
    {
        if (null == mInstance)
        {
            Init();
        }
        if (mInstance.textData.ContainsKey(key))
        {
            return mInstance.textData[key];
        }
        return "[NoDefine]" + key;
    }

}