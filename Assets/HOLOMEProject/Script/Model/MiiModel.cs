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
            // key�F�Փ˂����I�u�W�F�N�g�̖��O
            // value�F�A�j���[�V������boolean�̖��O
            { "face", "isFallDown" },
            { "body", "isHappy" },
/*            { "", "isFloat" },
            { "", "isGetUp" },
            { "", "isEat" },*/
        };
    }
}
