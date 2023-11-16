using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトの生成を行う。
/// </summary>
public class FbxLoader : MonoBehaviour
{
    public string gameObjectName;

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
            GameObject generatedObject = Instantiate(fbxObject);
            generatedObject.name = gameObjectName;
            generatedObject.transform.SetParent(transform, false);
            // sizeを調整する
            generatedObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            generatedObject.transform.SetPositionAndRotation(new Vector3(1f, 1f, 3f), Quaternion.Euler(1, 193, 1));

            Dictionary<string, string[]> gameObjectList = new()
                {
                    { "Mii", new string[] {"body", "face"} },
                    { "Holo", new string[] { } },
                };
            foreach (Transform child in generatedObject.transform)
            {
                // childのnameがgameObjectNameList[gameObjectName]に含まれているかどうか。
                if (Array.Exists(gameObjectList[gameObjectName], element => element == child.name))
                {
                    child.gameObject.AddComponent<BoxCollider>();
                    AddRigidBody(child.gameObject);
                }
            }

            AddAnimatorController(generatedObject);


            CharacterModel characterModel = AddCharacterModel(generatedObject);

            GameObject exfrowerObject = GameObject.Find("exfrower");
            CollisionDetection baseCollisionDetection = exfrowerObject.AddComponent<CollisionDetection>();
            baseCollisionDetection.SetCharacterModel(characterModel);

            generatedObject.AddComponent<HealthMonitor>();
        }
        else
        {
            Debug.LogError("FBXファイルが見つかりません: " + gameObjectName);
        }
    }

    /// <summary>
    /// 生成したObjectに対して、Animatorを追加する。
    /// </summary>
    private void AddAnimatorController(GameObject gameObject)    
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

    /// <summary>
    /// 生成したObjectに対して、CharacterModelを追加する。
    /// </summary>
    /// <returns>モデルのクラス</returns>
    private CharacterModel AddCharacterModel(GameObject childObject)
    {
        CharacterModel characterModel = childObject.AddComponent<CharacterModel>();
        characterModel.SetGameObject(childObject);
        characterModel.SetAnimatorParameters(childObject.GetComponent<Animator>().parameters);
        return characterModel;
    }
}
