using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTestButton : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        LoadingScene.Instance.LoadNextScene(sceneName);
    }
}