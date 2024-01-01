using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RhythmGameProject.Scripts.CoreSystem
{
    public class SceneController : MonoBehaviour
    {
        private Scene _lastScene; // 最後に読み込んだシーン
        private Scene _neverUnloadScene; //決してアンロードされないシーン（通常は初期シーン）

        void Awake()
        {
            // 初期化ロジック
            _neverUnloadScene = SceneManager.GetActiveScene();
            _lastScene = _neverUnloadScene;
        }

        /// <summary>
        /// 指定されたシーンを非同期で読み込む
        /// </summary>
        /// <param name="sceneName"> 読み込むシーンの名前 </param>
        public async UniTask LoadScene(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName)) return;
            await UnloadScene(_lastScene);
            await LoadSceneAdditive(sceneName);
        }

        /// <summary>
        /// 指定されたシーンを非同期でアンロードする
        /// </summary>
        /// <param name="scene"> アンロードするシーン </param>
        private async UniTask UnloadScene(Scene scene)
        {
            if (!scene.IsValid()) return;
            await SceneManager.UnloadSceneAsync(scene).ToUniTask();
            _lastScene = _neverUnloadScene;
        }

        /// <summary>
        /// 新しいシーンを追加的に非同期で読み込む
        /// </summary>
        /// <param name="sceneName"> 読み込むシーンの名前 </param>
        private async UniTask LoadSceneAdditive(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).ToUniTask();
            _lastScene = SceneManager.GetSceneByName(sceneName);
        }

        /// <summary>
        /// 最後に読み込まれたシーンを非同期でアンロードする
        /// </summary>
        public async UniTask UnloadLastScene()
        {
            if (!_lastScene.Equals(_neverUnloadScene))
                await UnloadScene(_lastScene);
        }
    }
}