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
    /// �I�u�W�F�N�g�𐶐����AHierarchy�ɒǉ�����B
    /// </summary>
    private void GenerateObject()
    {
        // �w�肵���t�@�C���ւ̃p�X����FBX�t�@�C����ǂݍ��ށB
        // Resources/Object/�ȉ��ɔz�u���邱�ƁB
        GameObject fbxObject = Resources.Load<GameObject>("Object/" + gameObjectName);

        if (fbxObject != null )
        {
            // FBX��Hierarchy�ɒǉ�����
            gameObject = Instantiate(fbxObject);
            gameObject.name = gameObjectName;
            gameObject.transform.SetParent(transform, false);
            // size�𒲐�����
            gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            // Animator��ǉ�
            AddAnimatorController();

            // box collider��ǉ�
            gameObject.AddComponent<BoxCollider>();

            // Rigidbody��ǉ�
            AddRigidBody();

            GameObject exfrowerObject = GameObject.Find("exfrower");
            exfrowerObject.AddComponent(gameObjectNameList[gameObjectName]);
        }
        else
        {
            Debug.LogError("FBX�t�@�C����������܂���: " + gameObjectName);
        }
    }

    /// <summary>
    /// ��������Object�ɑ΂��āAAnimator��ǉ�����B
    /// </summary>
    private void AddAnimatorController()    
    {
        // Animator��ǉ�
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
