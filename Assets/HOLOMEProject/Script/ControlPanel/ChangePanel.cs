using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowColorCustomizePanel : MonoBehaviour
{
    public GameObject ColorControlPanel;
    public GameObject BaseControlPanel;

    /// <summary>
    /// �J���[�J�X�^�}�C�Y�p�l�����\���ɂ���
    /// NOTO: �f�t�H���g�ŃJ���[�J�X�^�}�C�Y�p�l�����\���ɂ���Əォ��~���Ă��鋓���ɂȂ邽�ߕ\���̓R�[�h��ŊǗ�����
    /// </summary>
    void Start()
    {
        ColorControlPanel.SetActive(false);
    }

    /// <summary>
    /// �f�t�H���g�̃p�l�����\���ɂ��āA�J���[�J�X�^�}�C�Y�p�l����\������
    /// </summary>
    public void ChangeToColorCustomizePanel()
    {
        BaseControlPanel.SetActive(false);
        ColorControlPanel.SetActive(true);
    }

    /// <summary>
    /// �J���[�J�X�^�}�C�Y�p�l�����\���ɂ��ăf�t�H���g�̃p�l����\������
    /// </summary>
    public void ChangeToBaseControlPanel()
    {
        BaseControlPanel.SetActive(true);
        ColorControlPanel.SetActive(false);
    }
}
