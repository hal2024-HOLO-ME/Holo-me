using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowColorCustomizePanel : MonoBehaviour
{
    public GameObject ColorControlPanel;
    public GameObject BaseControlPanel;

    /// <summary>
    /// カラーカスタマイズパネルを非表示にする
    /// NOTO: デフォルトでカラーカスタマイズパネルを非表示にすると上から降ってくる挙動になるため表示はコード上で管理する
    /// </summary>
    void Start()
    {
        ColorControlPanel.SetActive(false);
    }

    /// <summary>
    /// デフォルトのパネルを非表示にして、カラーカスタマイズパネルを表示する
    /// </summary>
    public void ChangeToColorCustomizePanel()
    {
        BaseControlPanel.SetActive(false);
        ColorControlPanel.SetActive(true);
    }

    /// <summary>
    /// カラーカスタマイズパネルを非表示にしてデフォルトのパネルを表示する
    /// </summary>
    public void ChangeToBaseControlPanel()
    {
        BaseControlPanel.SetActive(true);
        ColorControlPanel.SetActive(false);
    }
}
