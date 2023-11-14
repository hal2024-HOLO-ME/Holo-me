using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiiModel : BaseCharacterModel
{
    public MiiModel()
    {
        gameObject = GameObject.Find("Mii");
        animationDictionary = new Dictionary<string, string>()
        {
            // key：衝突したオブジェクトの名前
            // value：アニメーションのbooleanの名前
            { "face", "isFallDown" },
            { "body", "isHappy" },
/*            { "", "isFloat" },
            { "", "isGetUp" },
            { "", "isEat" },*/
        };
    }
}
