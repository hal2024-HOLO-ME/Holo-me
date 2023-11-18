using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class AnimationTimer : MonoBehaviour
{
    private Animator animator;
    private HealthMonitor healthMonitor;
    private IDisposable timerAnimator = Disposable.Empty;
    private void Awake()
    {
        if (!gameObject.TryGetComponent(out animator)) return;
        if (!gameObject.TryGetComponent(out healthMonitor)) return;
    }

    void Start()
    {
        ObservableStateMachineTrigger trigger = animator.GetBehaviour<ObservableStateMachineTrigger>();

        // Idle��ԂɂȂ�����^�C�}�[���Z�b�g���A�J�E���g�_�E��������B
        trigger
           .OnStateEnterAsObservable()
           .Where(x => x.StateInfo.IsName("Idle"))
           .Subscribe(_ => {
               if (!healthMonitor.CheckSleepTime()) TimerSet();
           }).AddTo(this);

        // Idle��ԈȊO�ɂȂ�����^�C�}�[���~�߂�B
        trigger
            .OnStateEnterAsObservable()
            .Where(x => x.StateInfo.IsName("Idle") == false)
            .Subscribe(x =>
            {
                timerAnimator.Dispose();
            }).AddTo(this);
    }


    /// <summary>
    /// Timer��10�b�ɐݒ肷��B
    /// </summary>
    private void TimerSet()
    {
        timerAnimator.Dispose();

        timerAnimator = Observable
            .Timer(TimeSpan.FromSeconds(10))
            .Subscribe(_ => FireAnimatorTriggerWithTimer("HappyTrigger"))
            .AddTo(this);
    }

    /// <summary>
    /// �^�C�}�[����t���ŃA�j���[�V�����𔭉΂�����B
    /// </summary>
    /// <param name="triggerName"></param>
    private void FireAnimatorTriggerWithTimer(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

    void OnDestroy()
    {
        timerAnimator.Dispose();
    }
}
