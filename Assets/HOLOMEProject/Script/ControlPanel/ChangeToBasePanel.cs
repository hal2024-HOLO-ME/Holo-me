using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToBasePanel : MonoBehaviour
{
    public GameObject ColorControlPanel;
    public GameObject BaseControlPanel;

    /// <summary>
    /// カラー変更用パネルに切り替える
    /// </summary>
    public void ChangeToBaseControlPanel()
    {
        BaseControlPanel.SetActive(true);
        ColorControlPanel.SetActive(false);
    }
}
