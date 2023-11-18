using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UniRx;
using Unity.VisualScripting;

/// <summary>
/// �I�u�W�F�N�g�̏�Ԃ��Ď�����B
/// ����̎��ԑсi��F�������ԁj�ɑ΂��鏈�����s���B
/// </summary>
public class HealthMonitor : MonoBehaviour
{
    private CharacterModel characterModel;
    /// <summary>
    /// ��������(������)�̃g���K�[
    /// </summary>
    IDisposable minuteTimeTrigger;

    void Awake()
    {
        // CharacterModel���擾����
        characterModel = gameObject.GetComponent<CharacterModel>();

        // ���߂Ɉ����s���A�ȍ~��1�����Ɏ��s����B
        SetSleepStateIfInSleepTime();

        // 1�����Ƀg���K�[�����s����B
        minuteTimeTrigger = UniRx.Observable
            .Timer(TimeSpan.FromSeconds(60.0f - DateTime.Now.Second), TimeSpan.FromMinutes(1.0f))
            .SubscribeOnMainThread()
            .Subscribe(x =>
            {
                SetSleepStateIfInSleepTime();
            })
            .AddTo(this);
    }

    /// <summary>
    /// ���Ԕ͈͂Ȃ�A�Q��Ԃɂ���B
    /// </summary>
    private void SetSleepStateIfInSleepTime()
    {
        Animator animator = characterModel.GetGameObject().GetComponent<Animator>();

        bool isSleepTime = CheckSleepTime();

        bool isSleepAnimator = animator.GetBool("isSleep");
        if( !isSleepTime )
        {
            if( isSleepAnimator )
            {
                animator.SetBool("isSleep", false);
            }
            return;
        }

        // ���������͈̔͂̏ꍇ�́A������Ԃɂ���B
        animator.SetBool("isSleep", true);
    }

    /// <summary>
    /// �����������`�F�b�N����
    /// </summary>
    /// <returns>���������͈̔͂Ȃ�true��Ԃ�</returns>
    public bool CheckSleepTime()
    {
        int fromHour = 10;
        int limitHour = 17;
        TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
        TimeSpan startTime = new(fromHour, 0, 0);
        TimeSpan endTime = new(limitHour, 0, 0);

        // ���������͈͓̔����ǂ����𔻒肷��B
        return (startTime <= timeOfDay) && (timeOfDay <= endTime);
    }
}
