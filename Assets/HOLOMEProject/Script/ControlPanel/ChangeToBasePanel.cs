using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToBasePanel : MonoBehaviour
{
    public GameObject ColorControlPanel;
    public GameObject BaseControlPanel;

    /// <summary>
    /// �J���[�ύX�p�p�l���ɐ؂�ւ���
    /// </summary>
    public void ChangeToBaseControlPanel()
    {
        BaseControlPanel.SetActive(true);
        ColorControlPanel.SetActive(false);
    }
}
