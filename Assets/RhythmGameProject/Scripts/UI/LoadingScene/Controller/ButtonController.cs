using RhythmGameProject.Scripts.CoreSystem;
using UnityEngine;
using UnityEngine.UI;

namespace RhythmGameProject.Scripts.UI.LoadingScene.Controller
{
    public class ButtonController : MonoBehaviour
    {
        private Button _button;
    

        public void ChangeScene(string sceneName)
        {
            GameManager.Instance.LoadScene(sceneName);
        }

        public void SetActive(GameObject setActiveObject)
        {
            GameManager.Instance.SetActive(setActiveObject);
        }
    }
}