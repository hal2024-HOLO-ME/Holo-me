using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using MixedReality.Toolkit.UX;

public class Login : MonoBehaviour
{
    public MRTKUGUIInputField emailInputField;
    public MRTKUGUIInputField passwordInputField;
    public static string session;


    private void Start()
    {
        Debug.Log("スクリプトファイルを読み込んだ");
    }

    public void HandleLogin()
    {
        Debug.Log("ボタンが押された");
        string email = emailInputField.text; // メールアドレスを取得
        string password = passwordInputField.text; // パスワードを取得
        Debug.Log(email);
        Debug.Log(password);


        StartCoroutine(SendLoginRequest(email, password));
    }

    private IEnumerator SendLoginRequest(string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3001/auth/signin", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // when success
                Debug.Log("Login successful!");
                Debug.Log("Received: " + www.downloadHandler.text);
                session = www.downloadHandler.text;
                if (session != null)
                {
                    Debug.Log("sessionが取得できた");
                    // Sceneを遷移する
                    UnityEngine.SceneManagement.SceneManager.LoadScene("TopScene");
                    Debug.Log(session);


                    // loginButtonとemailInputFieldとpasswordInputFieldを非表示にする
                    // loginButton.gameObject.SetActive(false);
                    // emailInputField.gameObject.SetActive(false);
                    // passwordInputField.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("sessionが取得できなかった");
                }
                // ここで認証成功後の処理を行います
            }
        }
    }
}
