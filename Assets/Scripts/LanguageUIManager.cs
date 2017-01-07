using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageUIManager : MonoBehaviour {

    public void ChineseTraditional()
    {
        LanguageManager.ChineseTraditional();
        gameObject.SetActive(false);
    }
    public void ChineseSimplified()
    {
        LanguageManager.ChineseSimplified();
        gameObject.SetActive(false);
    }
    public void English()
    {
        LanguageManager.English();
        gameObject.SetActive(false);
    }
    public void Japanese()
    {
        LanguageManager.Japanese();
        gameObject.SetActive(false);
    }
}
