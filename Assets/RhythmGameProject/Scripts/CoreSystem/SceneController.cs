using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary> クラス名をSceneControllerに変更 </summary>
public class SceneController
{
    private Scene _lastScene;
    private readonly Scene _neverUnloadScene;

    ///<summary> コンストラクタ：最初に読み込まれるシーンはゲームのライフサイクルを通して破棄されません </summary>
    /// <param name="neverUnloadScene"> 最初に読み込まれるシーン </param>
    public SceneController(Scene neverUnloadScene)
    {
        _neverUnloadScene = neverUnloadScene;
        _lastScene = _neverUnloadScene;
    }

    ///<summary> シーンを非同期でロードするメソッド </summary>
    /// <param name="sceneName"> ロードするシーンの名前 </param>
    public async UniTask LoadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName)) return;

        await UnloadScene(_lastScene);
        await LoadSceneAdditive(sceneName);
    }

    ///<summary> シーンを非同期でロードするメソッド </summary>>
    public AsyncOperation LoadSceneAsync(string sceneName)
    {
        return SceneManager.LoadSceneAsync(sceneName);
    }


    // シーンを非同期でアンロードするメソッド
    private async UniTask UnloadScene(Scene scene)
    {
        if (!scene.IsValid()) return;
        await SceneManager.UnloadSceneAsync(scene).ToUniTask();
        _lastScene = _neverUnloadScene;
    }


    // 新しいシーンを追加で非同期でロードするメソッド
    private async UniTask LoadSceneAdditive(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).ToUniTask();
        _lastScene = SceneManager.GetSceneByName(sceneName);
    }


    // 最後にロードされたシーンを非同期でアンロードするメソッド
    public async UniTask UnloadLastScene()
    {
        if (!_lastScene.Equals(_neverUnloadScene))
            await UnloadScene(_lastScene);
    }
}