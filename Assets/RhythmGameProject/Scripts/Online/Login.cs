using UnityEngine;

namespace RhythmGameProject.Online
{
    public class Login : MonoBehaviour
    {
        //ログインエラーシーン
        [SerializeField] private string loginErrorSceneName = "LoginError";

        void Start()
        {
            //ログインチェック
            //if (PlayFabClientAPI.IsClientLoggedIn()) return;
            Debug.Log($"非ログイン状態のため{loginErrorSceneName}に移動します");
            GameManager.Instance.ChangeScene(loginErrorSceneName);
        }
    }
}