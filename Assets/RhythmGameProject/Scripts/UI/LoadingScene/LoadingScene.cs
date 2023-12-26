using UnityEngine;
using UnityEngine.UI;
using System;
using Cysharp.Threading.Tasks;

public class LoadingScene : MonoBehaviour
{
    private AsyncOperation _async;
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;

    public static LoadingScene Instance;

    public Action OnComplate;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public async UniTask LoadNextScene(string sceneName)
    {
        _loadingUI.SetActive(true);
        await UniTask.DelayFrame(1);
        _async = GameManager.Instance.LoadSceneAsync(sceneName);

        while (_async != null && !_async.isDone)
        {
            _slider.value = _async.progress;
            await UniTask.DelayFrame(1);
        }
        _loadingUI.SetActive(false);
        OnComplate?.Invoke();
    }
}
