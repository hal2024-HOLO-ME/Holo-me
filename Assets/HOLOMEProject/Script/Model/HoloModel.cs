using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloModel : BaseCharacterModel
{
    public HoloModel()
    {
        gameObject = GameObject.Find("Holo");
        animationDictionary = new Dictionary<string, string>()
        {
            { "right arm", "isRightArm" },
            { "left arm", "isLeftArm" },
        };
    }
}
