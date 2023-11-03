using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UniRx;

/// <summary>
/// オブジェクトの状態を監視する。
/// 特定の時間帯（例：睡眠時間）に対する処理を行う。
/// </summary>
public class HealthMonitor : MonoBehaviour
{
    /// <summary>
    /// 時刻判定(分刻み)のトリガー
    /// </summary>
    IDisposable p_MinuteTimeTrigger;

    // Start is called before the first frame update
    void Start()
    {
        // 1分毎にトリガーを実行する
        p_MinuteTimeTrigger = UniRx.Observable
            .Timer(TimeSpan.FromSeconds(60.0f - DateTime.Now.Second), TimeSpan.FromMinutes(1.0f))
            .SubscribeOnMainThread()
            .Subscribe(x =>
            {
                ChangeOverTimeCondition(DateTime.Now);
            })
            .AddTo(this);
    }

    /// <summary>
    /// 時間経過によるコンディション変化を管理する
    /// </summary>
    private void ChangeOverTimeCondition(DateTime a_DateTime)
    {
        Debug.Log("ChangeOverTimeCondition : " + a_DateTime.ToString());
        CheckSleepTime(a_DateTime);
    }

    /// <summary>
    /// 睡眠時刻をチェックする
    /// </summary>
    private void CheckSleepTime(DateTime a_DataTime)
    {
        int fromHour = 22;
        int limitHour = 6;
        TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
        TimeSpan startTime = new TimeSpan(fromHour, 0, 0);
        TimeSpan endTime = new TimeSpan(limitHour, 0, 0);

        // 睡眠時刻の範囲内かどうかを判定する。
        if ((startTime <= timeOfDay) && (timeOfDay <= endTime))
        {
            // 範囲内の場合は、睡眠時刻の処理を行う。
        }
    }
}
