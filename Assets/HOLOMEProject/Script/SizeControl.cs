using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ContactScript;

public class SizeControl : MonoBehaviour
{
    private float size = 0.1f;
    public float grow = 0f;
    //比べるためのカウントの保管
    int ChangeCount;
    //Contactスクリプトからcount(ふれあい度)を持ってきてる
    int ContactCount => Contact.count;

    void Start()
    {

        //サイズ変更の監視(ふれあい度からのカウント)
        ChangeCount = ContactCount;
        //大きさの初期値
         transform.localScale = new Vector3(size, size, size);


    }

    void Update()
    {

        // 前のフレームから値が変わったかどうか？
        if (ContactCount != ChangeCount)
        {
            try
            {
                OnValueChanged(); // 変数が変わったときの処理の呼び出し
            }
            finally
            {
                // 次の判定のために今の値を覚えておく
                ChangeCount = ContactCount;
            }
        }

    }

    /// <summary>
    /// ふれあい度が変わったときの処理
    /// ふれあい度に応じて大きさ変化、現時点では段階で分けてる
    /// 成長の割合についてはissu#31にて解決予定
    /// </summary>
    void OnValueChanged() 
    {
       
        switch (ContactCount)
        {
            case 1:
                grow = 0.5f;
                // Debug.Log("成長１："+ grow+ ":おおきさ:"+ size);
                StartCoroutine("ScaleUp");
                break; 
             case 2: 
                grow = 1f;
                // Debug.Log("成長２："+ grow+ ":おおきさ:"+ size);
                StartCoroutine("ScaleUp");
                break;
            case 3: 
                grow = 1.5f;
                // Debug.Log("成長３");
                StartCoroutine("ScaleUp");
                break;
            default:
                break;
            
        }
    }

     //徐々に大きくする
    IEnumerator ScaleUp()
    {

        for (float i = size; i < grow; i += 0.1f)
        {
            transform.localScale = new Vector3(i, i, i);
            size = i;
            yield return new WaitForSeconds(0.1f);
        }

    }


}
