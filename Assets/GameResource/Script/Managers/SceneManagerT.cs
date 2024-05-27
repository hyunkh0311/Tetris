using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerT : MonoBehaviour
{

    public void LoadScene(Define.Scene sceneName)
    {
        SceneManager.LoadScene(GetSceneName(sceneName));
    }

    public string GetSceneName(Define.Scene _sceneType)
    {
        switch (_sceneType)
        {
            case Define.Scene.StartScene:
                return "StartScene";
            case Define.Scene.GameScene:
                return "GameScene";
            case Define.Scene.LoadingScene:
                return "LoadingScene";
            default:
                throw new ArgumentOutOfRangeException(nameof(_sceneType));
        }
    }
}
