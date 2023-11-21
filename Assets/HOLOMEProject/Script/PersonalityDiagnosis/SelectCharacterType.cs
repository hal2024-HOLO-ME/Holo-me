using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.UX;

public class SelectCharacterType : MonoBehaviour
{
    public ToggleCollection toggleCollection;
    public static int characterType;

    /// <summary>
    /// �L�����N�^�[�̃^�C�v��I������
    /// �u0�v�FNormal�^�C�v
    /// �u1�v�FGhost�^�C�v
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
