using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class FbxLoader : MonoBehaviour
{
    public string gameObjectName;
    private new GameObject gameObject;
    public Dictionary<string, (string[],Type)> gameObjectNameList = new()
    {
        { "Mii", (new string[] {"body", "face"}, typeof(MiiCollisionDetection)) },
        { "Holo", (new string[] {}, typeof(HoloCollisionDetection)) },
    };

    public FbxLoader() { }

    public FbxLoader(string gameObjectName)
    {
        this.gameObjectName = gameObjectName;
    }

    private void Awake()
    {
        GenerateObject();
    }

    /// <summary>
    /// オブジェクトを生成し、Hierarchyに追加する。    /// </summary>
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
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            gameObject.transform.position = new Vector3(1f, 1f, 3f);
            gameObject.transform.rotation = Quaternion.Euler(1, 193, 1);

            foreach (Transform child in gameObject.transform)
            {
                // childのnameがgameObjectNameList[gameObjectName].Item1に含まれているかどうか。
                if (Array.Exists(gameObjectNameList[gameObjectName].Item1, element => element == child.name))
                {
                    child.gameObject.AddComponent<BoxCollider>();
                    AddRigidBody(child.gameObject);
                }
            }

            AddAnimatorController();

            GameObject exfrowerObject = GameObject.Find("exfrower");
            exfrowerObject.AddComponent(gameObjectNameList[gameObjectName].Item2);
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
        Animator animator = gameObject.AddComponent<Animator>();
        RuntimeAnimatorController controller = Resources.Load("animation/"+ gameObjectName
            +" Animator Controller") as RuntimeAnimatorController;
        animator.runtimeAnimatorController = controller;
    }

    /// <summary>
    /// 生成したObjectに対して、RigidBodyを追加する。
    /// </summary>
    private void AddRigidBody(GameObject childObject)
    {
        Rigidbody rigidbody = childObject.AddComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
}
