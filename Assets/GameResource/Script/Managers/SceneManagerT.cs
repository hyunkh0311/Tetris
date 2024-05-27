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
            case Define.Scene.GameSCene:
                return "GameScene";
            default:
                throw new ArgumentOutOfRangeException(nameof(_sceneType));
        }
    }
}
