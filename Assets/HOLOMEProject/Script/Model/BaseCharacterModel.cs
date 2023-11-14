using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterModel : MonoBehaviour
{
    protected new GameObject gameObject;
    protected Dictionary<string, string> animationDictionary;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void SetGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
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
