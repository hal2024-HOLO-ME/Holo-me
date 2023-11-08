using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiiModel : MonoBehaviour
{
    private new GameObject gameObject;
    private Dictionary<string, string> animationDictionary;

    private void Awake()
    {
        gameObject = GameObject.Find("Mii");
        animationDictionary = new Dictionary<string, string>()
        {
            { "Mii", "isMove" },
            //{ "mii", "isFloat" },
            //{ "mii", "isShakingHead" },
        };
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void AddAnimationDictionary(string key, string value)
    {
        animationDictionary.Add(key, value);
    }

    public Dictionary<string, string> GetAnimationDictionary()
    {
        return animationDictionary;
    }
}
