using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using I2.Loc;
using DragonBones;

public class test : MonoBehaviour
{
    private static readonly string[] HEAD_LIST = { "head", "head2", "head3" };
    private static readonly string[] HAIR_LIST = { "hair1", "hair2", "hair3" };
    public int headIndex = 0;
    private Armature head = null;
    UnityArmatureComponent armatureComponent;
    void Start()
    {
        //// Load data.
        //UnityFactory.factory.LoadDragonBonesData("Animations/soldiers_ske"); // DragonBones file path (without suffix)
        //UnityFactory.factory.LoadTextureAtlasData("Animations/soldiers_tex"); //Texture atlas file path (without suffix) 
        //                                                            // Create armature.
        //var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature"); // Input armature name
        //                                                                              // Play animation.
        //armatureComponent.animation.Play("idle");

        //// Change armatureposition.
        //armatureComponent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);


        armatureComponent = GetComponent<UnityArmatureComponent>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _switchWeaponLeft();
        }
    }
    private void _switchWeaponLeft()
    {
        headIndex++;
        if (headIndex >= HEAD_LIST.Length)
        {
            headIndex = 0;
        }


        var headName = HEAD_LIST[headIndex];

        UnityFactory.factory.ReplaceSlotDisplay("soldiers", "Armature", "head", HEAD_LIST[headIndex], armatureComponent.armature.GetSlot("head"));
    }
}
