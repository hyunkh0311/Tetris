using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class StartSceneInit : MonoBehaviour
{
    public Button startBtn;

    private void Start()
    {
        startBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Managers.Scene.LoadScene(Define.Scene.GameScene);
        });
    }
}
