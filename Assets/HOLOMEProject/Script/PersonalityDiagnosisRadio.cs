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
        // �����\����CurrentIndex��0�Ȃ̂ŁA����𔽉f������
        SetAnswerCountBasedOnCurrentIndex();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ���W�I�{�^���̏�����ԂɊ�Â���answer_count��ݒ�
    private void SetAnswerCountBasedOnCurrentIndex()
    {
        if (toggleCollection.CurrentIndex == 1)
        {
            answer_count++;
            Debug.Log("answer_count���v���X����" + answer_count);
        }
        else if (toggleCollection.CurrentIndex == 0)
        {
            answer_count--;
            Debug.Log("answer_count���}�C�i�X����" + answer_count);
        }
    }

    // toggleCollection�̒��g���擾����
    public void OnClick()
    {
        if (toggleCollection.CurrentIndex == 1)
        {
            answer_count++;
            Debug.Log("answer_count���v���X����" + answer_count);
        }
        else if (toggleCollection.CurrentIndex == 0)
        {
            answer_count--;
            Debug.Log("answer_count���}�C�i�X����" + answer_count);
        }
        Debug.Log("CurrentIndex" + toggleCollection.CurrentIndex);
    }
}
