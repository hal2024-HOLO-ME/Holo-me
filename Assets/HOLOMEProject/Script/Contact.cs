using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ContactScript
{
    public class Contact : MonoBehaviour
    {

        //秒数カウント用
        private int fixcount = 0;
        //fixcountをわかりやすくしたもの(50ずつだったものを１秒２秒の表記に直した)
        private int miunte = 0;
        //過剰に増えさせないためのインターバル
        private int interbal = 0;
        //ふれあい度
        public static int count = 0;


        // 中に記述された処理が一定間隔で繰り返し実行される
        void FixedUpdate()
        {

            if (fixcount % 50 == 0)
            {
                miunte = fixcount / 50;
                Debug.Log(miunte);
            }
            if (fixcount >= 4320000)
            {
                fixcount = 0; // 24時間分カウントアップしたら初期化する
            }
            fixcount++; // カウントアップ

        }

        // ゲームオブジェクト同士が接触している間、持続的に実行
        void OnCollisionStay(Collision collision)
        {
           
            if (fixcount % 50 == 0 && interbal <= miunte)
            {
                    count += 1;
                    Debug.Log("触れ合い" + count);
                    interbal = miunte + 5;
                    Debug.Log("インターバル" + interbal);
                }

        }
        

    }
}
