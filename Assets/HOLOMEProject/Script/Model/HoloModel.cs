using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloModel : MonoBehaviour
{
    private new GameObject gameObject;
    private Dictionary<string, string> animationDictionary;
    
    private void Awake()
    {
        gameObject = GameObject.Find("holo");
        animationDictionary = new Dictionary<string, string>()
        {
            { "right arm", "isRightArm" },
            { "left arm", "isLeftArm" },
        };
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Dictionary<string, string> GetAnimationDictionary()
    {
        return animationDictionary;
    }

    public void AddAnimationDictionary(string key, string value)
    {
        animationDictionary.Add(key, value);
    }
}
