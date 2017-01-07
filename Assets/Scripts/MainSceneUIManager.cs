using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUIManager : MonoBehaviour {
    public GameObject panel_langFirst;
    public GameObject panel_main;
    public GameObject panel_langOption;

    void Awake()
    {
        panel_main.SetActive(true);
        panel_langFirst.SetActive(false);
        panel_langOption.SetActive(false);


        if (!PlayerPrefs.HasKey("I2 Language"))
        {
            panel_langFirst.SetActive(true);
        }
    }
    
    public void OnClickStart()
    {
        SceneManager.LoadSceneAsync("menuscene");
    }
    public void OnClickEvaluate()
    {
    }
    public void OnClickAbout()
    {

    }
    public void OnClickLanguage()
    {
        panel_langOption.SetActive(true);
    }
    public void OnClickClose()
    {
        panel_langOption.SetActive(false);
    }
}
