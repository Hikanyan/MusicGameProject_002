using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    
    [SerializeField] private Slider slider;
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private float minimumLoadTime = 2.0f;

    public static LoadingScene Instance { get; private set; }
    private AsyncOperation _async;
    private Action _onComplete;

    private void Awake()
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

    public async UniTask LoadNextScene(string sceneName)
    {
        await FadeOut();

        loadingUI.SetActive(true);
        var startTime = Time.time;
        var targetProgress = 0f;
        var displayProgress = 0f;

        _async = GameManager.Instance.LoadSceneAsync(sceneName);

        while (Time.time - startTime < minimumLoadTime || _async is { isDone: false })
        {
            if (_async != null)
            {
                targetProgress = Mathf.Clamp01(_async.progress);
            }

            // プログレスバーを滑らかに進める
            displayProgress = Mathf.MoveTowards(displayProgress, targetProgress, Time.deltaTime / minimumLoadTime);
            slider.value = displayProgress;

            await UniTask.DelayFrame(1);
        }

        loadingUI.SetActive(false);
        _onComplete?.Invoke();

        await FadeIn();
    }

    private async UniTask FadeOut()
    {
        // DOTweenアニメーションを待機する
        await fadeCanvasGroup.DOFade(1, fadeDuration).AsyncWaitForCompletion();
    }

    private async UniTask FadeIn()
    {
        // DOTweenアニメーションを待機する
        await fadeCanvasGroup.DOFade(0, fadeDuration).AsyncWaitForCompletion();
    }
}