using UnityEngine;


/// <summary> リズムゲームの進行管理を行うクラス </summary>
public class RythemGameManager : MonoBehaviour
{
    // 音楽の再生や停止を管理
    // タイミングのチェックなど
    
    public static RythemGameManager Instance { get; private set; }

    private void Awake()
    {
        Singleton();
    }


    /// <summary> シングルトンではあるが、シーンをまたいで存在する必要がないため、DontDestroyOnLoadはしない </summary>
    private void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Initialize()
    {
    }
}