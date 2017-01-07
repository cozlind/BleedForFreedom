using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using I2.Loc;

public class LanguageManager {

    private static string TW = "Chinese (Traditional)";
    private static string CN = "Chinese (Simplified)";
    private static string EN = "English";
    private static string JP = "Japanese";

    public static void ChineseTraditional()
    {
        if (LocalizationManager.HasLanguage(TW))
        {
            LocalizationManager.CurrentLanguage = TW;
        }
    }

    public static void ChineseSimplified()
    {
        if (LocalizationManager.HasLanguage(CN))
        {
            LocalizationManager.CurrentLanguage = CN;
        }
    }
    public static void English()
    {
        if (LocalizationManager.HasLanguage(EN))
        {
            LocalizationManager.CurrentLanguage = EN;
        }
    }
    public static void Japanese()
    {
        if (LocalizationManager.HasLanguage(JP))
        {
            LocalizationManager.CurrentLanguage = JP;
        }
    }
}
