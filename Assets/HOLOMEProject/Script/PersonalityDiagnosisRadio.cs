using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using MixedReality.Toolkit.UX;
using UnityEngine;


public class PersonalityDiagnosisRadio : MonoBehaviour
{
    public ToggleCollection toggleCollection;
    public static int answer_count;

    // Start is called before the first frame update
    void Start()
    {
        // 初期表示はCurrentIndexが0なので、それを反映させる
        SetAnswerCountBasedOnCurrentIndex();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ラジオボタンの初期状態に基づいてanswer_countを設定
    private void SetAnswerCountBasedOnCurrentIndex()
    {
        if (toggleCollection.CurrentIndex == 1)
        {
            answer_count++;
            Debug.Log("answer_countをプラスした" + answer_count);
        }
        else if (toggleCollection.CurrentIndex == 0)
        {
            answer_count--;
            Debug.Log("answer_countをマイナスした" + answer_count);
        }
    }

    // toggleCollectionの中身を取得する
    public void OnClick()
    {
        if (toggleCollection.CurrentIndex == 1)
        {
            answer_count++;
            Debug.Log("answer_countをプラスした" + answer_count);
        }
        else if (toggleCollection.CurrentIndex == 0)
        {
            answer_count--;
            Debug.Log("answer_countをマイナスした" + answer_count);
        }
        Debug.Log("CurrentIndex" + toggleCollection.CurrentIndex);
    }
}
