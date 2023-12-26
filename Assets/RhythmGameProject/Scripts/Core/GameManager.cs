using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ゲームフローの管理を行うクラス
 */
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Initialize()
    {
        // ゲームの初期化処理
        // セーブデータの読み込み
        // シーンの読み込み
        //
        
    }

    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    
    public void SetActive(GameObject setActiveObject)
    {
        setActiveObject.SetActive(!setActiveObject.activeSelf);
    }
    
    // ゲームの状態を管理する
    
    
}
