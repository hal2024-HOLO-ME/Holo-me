using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloCollisionDetection : BaseCollisionDetection
{
    private HoloModel holoModel;

    private void Awake()
    {
        holoModel = gameObject.AddComponent<HoloModel>();
    }

    protected override GameObject GetGameObject()
    {
        return holoModel.GetGameObject();
    }

    protected override Dictionary<string, string> GetAnimationDictionary()
    {
        return holoModel.GetAnimationDictionary();
    }
}
