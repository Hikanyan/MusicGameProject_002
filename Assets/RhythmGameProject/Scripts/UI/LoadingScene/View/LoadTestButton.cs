using UnityEngine;

namespace RhythmGameProject.Scripts.UI.LoadingScene.View
{
    public class LoadTestButton : MonoBehaviour
    {
        
        public LoadingSceneView loadingScene;

        public void OnButtonClick()
        {
            loadingScene.LoadScene("LoadingScene1");
        }
        public void LoadScene(string sceneName)
        {
            LoadingScene.Instance.LoadNextScene(sceneName);
        }
        
    }
}