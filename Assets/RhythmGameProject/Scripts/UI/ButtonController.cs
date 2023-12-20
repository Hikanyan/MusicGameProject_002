using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button _button;
    

    public void ChangeScene(string sceneName)
    {
        GameManager.Instance.ChangeScene(sceneName);
    }

    public void SetActive(GameObject setActiveObject)
    {
        GameManager.Instance.SetActive(setActiveObject);
    }
}