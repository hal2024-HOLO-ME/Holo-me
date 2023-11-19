using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacheScript{
public class Tatch : MonoBehaviour
{
    // Start is called before the first frame update
    
    //カウント用
    private int fixcount = 0;
    //fixcountをわかりやすくしたもの(50ずつだったものを１秒２秒の表記に直した)
    private int miunte = 0;
    //過剰に増えさせないためのインターバル
    private int interbal = 0;
    //ふれあい度
    public static int count = 0;
    

     // 中に記述された処理が一定間隔で繰り返し実行される
    void FixedUpdate() {

       
        if (fixcount % 50 == 0) {
           miunte = fixcount/50;
            Debug.Log(miunte);
        }
        if (fixcount >= 4320000){
            fixcount = 0; // 24時間分カウントアップしたら初期化する
        }
        fixcount++; // カウントアップ

        // もし入力したキーがSpaceキーならば、中の処理を実行する
        if (Input.GetKey(KeyCode.Space)) {
            // このオブジェクトのRigidbodyコンポーネントのAddForce関数を呼び出し
            // Z軸方向に5.0fの力を、質量を考慮して瞬間的(ForceMode.Impulse)に加える
            GetComponent<Rigidbody>().AddForce(0, 0, 5.0f, ForceMode.Impulse);
        }

        
    }

     //OnCollisionEnter()
//     void OnCollisionEnter(Collision collision)
// {
//     // もし衝突した相手オブジェクトの名前が"Cube"ならば
//     if (collision.gameObject.name == "Cube") {
//         // 衝突した相手オブジェクトを削除する
//         Destroy(collision.gameObject);
//     }   
// }

// ゲームオブジェクト同士が接触している間、持続的に実行
void OnCollisionStay(Collision collision)
{
     if (fixcount % 50 == 0 && interbal <= miunte) {
        
    // もし接触している相手オブジェクトの名前が"Plane"ならば
    if (collision.gameObject.name == "Mii"){

         count += 1;
        Debug.Log("ふれあい度："+count);
        interbal = miunte + 5;
        Debug.Log("インターバル："+interbal);
    }
        // }
     }
}

}
}
