using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FbxLoader : MonoBehaviour
{
    public string gameObjectName;
    private new GameObject gameObject;
    public Dictionary<string, Type> gameObjectNameList = new()
    {
        { "Mii", typeof(MiiCollisionDetection) },
        { "Holo", typeof(HoloCollisionDetection) },
    };

    private void Awake()
    {
        GenerateObject();
    }

    /// <summary>
    /// オブジェクトを生成し、Hierarchyに追加する。
    /// </summary>
    private void GenerateObject()
    {
        // 指定したファイルへのパスからFBXファイルを読み込む。
        // Resources/Object/以下に配置すること。
        GameObject fbxObject = Resources.Load<GameObject>("Object/" + gameObjectName);

        if (fbxObject != null )
        {
            // FBXをHierarchyに追加する
            gameObject = Instantiate(fbxObject);
            gameObject.name = gameObjectName;
            gameObject.transform.SetParent(transform, false);
            // sizeを調整する
            gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            // Animatorを追加
            AddAnimatorController();

            // box colliderを追加
            gameObject.AddComponent<BoxCollider>();

            // Rigidbodyを追加
            AddRigidBody();

            GameObject exfrowerObject = GameObject.Find("exfrower");
            exfrowerObject.AddComponent(gameObjectNameList[gameObjectName]);
        }
        else
        {
            Debug.LogError("FBXファイルが見つかりません: " + gameObjectName);
        }
    }

    /// <summary>
    /// 生成したObjectに対して、Animatorを追加する。
    /// </summary>
    private void AddAnimatorController()    
    {
        // Animatorを追加
        Animator animator = gameObject.AddComponent<Animator>();
        RuntimeAnimatorController controller = Resources.Load("animation/"+ gameObjectName
            +" Animator Controller") as RuntimeAnimatorController;
        animator.runtimeAnimatorController = controller;
    }

    private void AddRigidBody()
    {
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
}
