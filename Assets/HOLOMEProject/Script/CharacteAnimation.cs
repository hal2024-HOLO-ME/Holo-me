using UnityEngine;
using UniRx;
using System;

public class AnimationTimer : MonoBehaviour
{
    private Animator animator;
    private IDisposable timerAnimator = Disposable.Empty;
    private IDisposable timerFlagOff = Disposable.Empty;
    private string[] parameterNames = { "isFallDown", "isHappy", "isFloat","isGetUp","isEat" };

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null) return;

        var parameterChangedSubject = new Subject<Unit>();

        Observable.EveryUpdate()
            .Select(_ => IsAnyParameterChanged())
            .DistinctUntilChanged()
            .Subscribe(_ => parameterChangedSubject.OnNext(Unit.Default))
            .AddTo(this);

        timerAnimator = Observable
            .Timer(TimeSpan.FromSeconds(10))
            .Subscribe(_ => OnTimerExpired())
            .AddTo(this);
    }


    private bool IsAnyParameterChanged()
    {
        foreach (var paramName in parameterNames)
        {
            if (animator.GetBool(paramName))
            {
                //����Animetor���N��������J�E���g�_�E�����J�n����
                timerAnimator.Dispose();
                timerAnimator = Observable
                    .Timer(TimeSpan.FromSeconds(10))
                    .Subscribe(_ => OnTimerExpired())
                    .AddTo(this);
                return true;
            }
        }
        return false;
    }

    void OnTimerExpired()
    {
        animator.SetBool("isFallDown", true);

        //10�b���炢��true��false�ɂ���ianimation�̎��Ԏ���j
        timerFlagOff.Dispose();
        timerFlagOff = Observable
            .Timer(TimeSpan.FromSeconds(5))
            .Subscribe(_ => OffFlag())
            .AddTo(this);
    }

    void OffFlag()
    {
        animator.SetBool("isFallDown", false);
    }

    void OnDestroy()
    {
        timerAnimator.Dispose();
        timerFlagOff.Dispose() ;
    }
}
