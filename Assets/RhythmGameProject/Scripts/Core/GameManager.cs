using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ゲーム全体のゲームフローの管理を行うクラス
 */
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private SaveAndLoad _saveAndLoad;
    private RythemGameManager _rythemGameManager;

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
        // ゲームの状態の初期化
        
        
        
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    
    //AsyncOperationは非同期処理の結果を取得するためのクラス
    public AsyncOperation LoadSceneAsync(string sceneName)
    {
        return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
    }
    
    public void SetActive(GameObject setActiveObject)
    {
        setActiveObject.SetActive(!setActiveObject.activeSelf);
    }
    
    // ゲームの状態を管理する
    
    
}
