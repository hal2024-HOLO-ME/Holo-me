using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.UX;

public class SelectCharacterType : MonoBehaviour
{
    public ToggleCollection toggleCollection;
    public static int characterType;

    /// <summary>
    /// キャラクターのタイプを選択する
    /// 「0」：Normalタイプ
    /// 「1」：Ghostタイプ
    /// </summary>
    public void OnToggleClick()
    {
        if (toggleCollection.CurrentIndex == 0)
        {
            characterType = 0;
        }
        else if (toggleCollection.CurrentIndex == 1)
        {
            characterType = 1;
        }
    }
}
