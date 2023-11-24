using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToShowCharacterScene : MonoBehaviour
{

    /// <summary>
    /// キャラクターを表示用のシーンに移動
    /// </summary>
    public void MoveToShowCharacterScener()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ShowCharacterScene");
    }
}
