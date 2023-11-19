using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRegisterScene : MonoBehaviour
{
    // Move to Register Scene
    public void MoveToRegister()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("RegisterScene");
    }
}
