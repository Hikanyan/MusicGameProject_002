using UnityEngine;

/// <summary> 観察されたゲームやイベントに基づいてゲームの状態を決定します。 </summary>
public class SequenceManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _preloadedAssets;
    public static SequenceManager Instance { get; private set; }

    /// <summary> 初期化 </summary>
    public void Initialize()
    {
        Singleton();
        InstantiatePreloadedAssets();
    }

    /// <summary> シングルトンではあるが、シーンをまたいで存在する必要がないため、DontDestroyOnLoadはしない </summary>
    void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary> 登録されたPrefabを全てインスタンス化 </summary>
    private void InstantiatePreloadedAssets()
    {
        foreach (var asset in _preloadedAssets)
        {
            Instantiate(asset);
        }
    }
    
    
    
}