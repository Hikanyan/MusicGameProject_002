// using UnityEngine.SceneManagement;
//
// namespace RhythmGameProject.UI
// {
//     public class LoadingScene
//     {
//         
//         public async UniTask LoadNextScene(string sceneName)
//         {
//             _loadingUI.SetActive(true);
//             await UniTask.DelayFrame(1);
//             _async = SceneManager.LoadSceneAsync(sceneName);
//
//             while (_async != null && !_async.isDone)
//             {
//                 _slider.value = _async.progress;
//                 await UniTask.DelayFrame(1);
//             }
//             _loadingUI.SetActive(false);
//             OnComplate?.Invoke();
//         }
//     }
// }