using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToColorPanel : MonoBehaviour
{
    public GameObject ColorControlPanel;
    public GameObject BaseControlPanel;

    /// <summary>
    /// �����\�����ɃJ���[�ύX�p�p�l�����\���ɂ���
    /// CHECK: �R�[�h��ŃJ���[�ύX�p�p�l�����\���ɂ��Ȃ��Ɛ؂�ւ����Ƃ��̋����Ɉ�a�������邽�߃R�[�h��ōs��
    /// </summary>
    void Start()
    {
        ColorControlPanel.SetActive(false);
    }

    /// <summary>
    /// �f�t�H���g�̃R���g���[���p�l���ɐ؂�ւ���
    /// </summary>

    public void ChangeToColorControlPanel()
    {
        ColorControlPanel.SetActive(true);
        BaseControlPanel.SetActive(false);
    }
}
