using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiiModel : MonoBehaviour
{
    private new GameObject gameObject;
    private Dictionary<string, string> animationDictionary;

    private void Awake()
    {
        gameObject = GameObject.Find("mii");
        animationDictionary = new Dictionary<string, string>()
        {
            { "mii", "isAnimation" },
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
