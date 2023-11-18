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
        Debug.Log("�X�N���v�g�t�@�C����ǂݍ���");
    }

    public void HandleLogin()
    {
        Debug.Log("�{�^���������ꂽ");
        string email = emailInputField.text; // ���[���A�h���X���擾
        string password = passwordInputField.text; // �p�X���[�h���擾
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
                    Debug.Log("session���擾�ł���");
                    // Scene��J�ڂ���
                    UnityEngine.SceneManagement.SceneManager.LoadScene("TopScene");
                    Debug.Log(session);


                    // loginButton��emailInputField��passwordInputField���\���ɂ���
                    // loginButton.gameObject.SetActive(false);
                    // emailInputField.gameObject.SetActive(false);
                    // passwordInputField.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("session���擾�ł��Ȃ�����");
                }
                // �����ŔF�ؐ�����̏������s���܂�
            }
        }
    }
}
