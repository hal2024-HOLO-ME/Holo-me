using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToColorPanel : MonoBehaviour
{
    public GameObject ColorControlPanel;
    public GameObject BaseControlPanel;

    /// <summary>
    /// 初期表示時にカラー変更用パネルを非表示にする
    /// CHECK: コード上でカラー変更用パネルを非表示にしないと切り替えたときの挙動に違和感があるためコード上で行う
    /// </summary>
    void Start()
    {
        ColorControlPanel.SetActive(false);
    }

    /// <summary>
    /// デフォルトのコントロールパネルに切り替える
    /// </summary>

    public void ChangeToColorControlPanel()
    {
        ColorControlPanel.SetActive(true);
        BaseControlPanel.SetActive(false);
    }
}
