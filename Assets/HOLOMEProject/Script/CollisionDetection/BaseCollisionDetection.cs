using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollisionDetection : MonoBehaviour
{
    protected Animator animator;
    protected Dictionary<string, string> animationDictionary;

    void Start()
    {
        // gameObject.name で オブジェクトを取得する
        GameObject gameObject = GetGameObject();

        // オブジェクトからanimatorを取得する
        animator = gameObject.GetComponent<Animator>();

        // 衝突時のアクションを定義する辞書を初期化する
        animationDictionary = GetAnimationDictionary();
    }

    protected virtual GameObject GetGameObject()
    {
        return gameObject;
    }

    protected virtual Dictionary<string, string> GetAnimationDictionary()
    {
        return new Dictionary<string, string>();
    }

    /// <summary>
    ///  ゲームオブジェクト同士が接触したタイミングで実行
    /// </summary>
    public void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトの名前を取得
        string collisionObjectName = collision.gameObject.name;
        HandleCollision(collisionObjectName);
    }

    /// <summary>
    /// 衝突したオブジェクトの名前を元にアニメーションを実行する
    /// </summary>
    private void HandleCollision(string collisionObjectName)
    {
        if (animationDictionary.ContainsKey(collisionObjectName))
        {
            bool IsAnimation = animator.GetBool(animationDictionary[collisionObjectName]);
            animator.SetBool(animationDictionary[collisionObjectName], !IsAnimation);
        }
    }
}
