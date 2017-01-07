using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUIManager : MonoBehaviour {

	public void OnClickYes()
    {
        PlayerPrefs.DeleteKey("bleed_character");
        gameObject.SetActive(false);
    }
    public void OnClickNo()
    {
        gameObject.SetActive(false);
    }
}
