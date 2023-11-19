using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLoginScene : MonoBehaviour
{
    public void MoveToLogin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoginScene");
    }
}
