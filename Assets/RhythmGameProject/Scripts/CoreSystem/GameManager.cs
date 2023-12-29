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
    private RhythmGameManager _rhythmGameManager;
    private SceneController _sceneController;

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
    
    /// <summary> シーンを非同期で読み込む </summary>
    /// <param name="sceneName">読み込むシーンの名前</param>
    public AsyncOperation LoadSceneAsync(string sceneName)
    {
        return _sceneController.LoadSceneAsync(sceneName);
    }
    
    /// <summary> GameObjectのアクティブを切り替える </summary>
    /// <param name="setActiveObject">アクティブを切り替えるGameObject</param> 
    public void SetActive(GameObject setActiveObject)
    {
        setActiveObject.SetActive(!setActiveObject.activeSelf);
    }
    
    // ゲームの状態を管理する
    
    
}
