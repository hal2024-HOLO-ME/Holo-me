using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiiCollisionDetection : BaseCollisionDetection
{
    private MiiModel miiModel;

    private void Awake()
    {
        miiModel = gameObject.AddComponent<MiiModel>();
    }

    public void SetMiiModel(MiiModel miiModel)
    {
        this.miiModel = miiModel;
    }

    protected override GameObject GetGameObject()
    {
        return miiModel.GetGameObject();
    }

    protected override Dictionary<string, string> GetAnimationDictionary()
    {
        return miiModel.GetAnimationDictionary();
    }
}
