using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class MenuSceneUIManager : MonoBehaviour {

    public GameObject panel_appearence;
    public GameObject panel_position;
    public GameObject panel_delete;
    public GameObject icon_character;

    void Awake()
    {
        PlayerPrefs.DeleteKey("bleed_character");


        armature = icon_character.GetComponent<UnityArmatureComponent>().armature;
        icon_character.SetActive(false);
        panel_appearence.SetActive(false);
        panel_position.SetActive(true);
        panel_delete.SetActive(false);

        if (!PlayerPrefs.HasKey("bleed_character"))
        {
            icon_character.SetActive(true);
            panel_appearence.SetActive(true);
        }
        else
        {
            string[] str = PlayerPrefs.GetString("bleed_character").Split(',');
            headIndex = int.Parse(str[0]);
            hairIndex = int.Parse(str[1]);
            hairColorIndex = int.Parse(str[2]);

            UnityFactory.factory.ReplaceSlotDisplay("soldiers", "Armature", "hair11", HAIRARRAY[hairIndex], armature.GetSlot("hair11"));
            UnityFactory.factory.ReplaceSlotDisplay("soldiers", "Armature", "head", HEADARRAY[headIndex], armature.GetSlot("head"));
            ColorTransform color = new ColorTransform();
            color.redMultiplier = HAIRCOLORARRAY[hairColorIndex];
            armature.GetSlot("hair11")._setColor(color);
        }
    }
    public void OnClickDelete()
    {
        panel_delete.SetActive(true);
    }

    #region panel appearence
    private Armature armature;
    private int headIndex = 0;
    private int hairIndex = 0;
    private int hairColorIndex = 0;
    private static readonly string[] HEADARRAY = { "head", "head2", "head3" };
    private static readonly string[] HAIRARRAY = { "hair1", "hair2", "hair3" };
    private static readonly float[] HAIRCOLORARRAY = { 0.4f,0.7f,1f};

    public void OnClickFaceLeft()
    {
        headIndex = (headIndex - 1+ HEADARRAY.Length) % HEADARRAY.Length;
        UnityFactory.factory.ReplaceSlotDisplay("soldiers", "Armature", "head", HEADARRAY[headIndex], armature.GetSlot("head"));
    }
    public void OnClickFaceRight()
    {
        headIndex = (headIndex + 1 + HEADARRAY.Length) % HEADARRAY.Length;
        UnityFactory.factory.ReplaceSlotDisplay("soldiers", "Armature", "head", HEADARRAY[headIndex], armature.GetSlot("head"));
    }
    public void OnClickHairLeft()
    {
        hairIndex = (hairIndex - 1 + HAIRARRAY.Length) % HAIRARRAY.Length;
        UnityFactory.factory.ReplaceSlotDisplay("soldiers", "Armature", "hair11", HAIRARRAY[hairIndex], armature.GetSlot("hair11"));
    }
    public void OnClickHairRight()
    {
        hairIndex = (hairIndex + 1 + HAIRARRAY.Length) % HAIRARRAY.Length;
        UnityFactory.factory.ReplaceSlotDisplay("soldiers", "Armature", "hair11", HAIRARRAY[hairIndex], armature.GetSlot("hair11"));
    }
    public void OnClickHairColorLeft()
    {
        hairColorIndex = (hairColorIndex - 1 + HAIRCOLORARRAY.Length) % HAIRCOLORARRAY.Length;
        ColorTransform color = new ColorTransform();
        color.redMultiplier = HAIRCOLORARRAY[hairColorIndex];
        armature.GetSlot("hair11")._setColor(color);
    }
    public void OnClickHairColorRight()
    {
        hairColorIndex = (hairColorIndex + 1 + HAIRCOLORARRAY.Length) % HAIRCOLORARRAY.Length;
        ColorTransform color = new ColorTransform();
        color.redMultiplier = HAIRCOLORARRAY[hairColorIndex];
        armature.GetSlot("hair11")._setColor(color);
    }
    public void OnClickComplete()
    {
        PlayerPrefs.SetString("bleed_character", headIndex + "," + hairIndex + "," + hairColorIndex);
        panel_appearence.SetActive(false);
    }
    #endregion
}
